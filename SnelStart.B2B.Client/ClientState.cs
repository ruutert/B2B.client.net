using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client
{

    internal class ClientState
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private IRequestInterceptor[] _defaultInterceptors;

        public Config Config { get; }
        public string AccessToken { get; internal set; }
        public DateTime RenewTokenBefore { get; set; }

        public ClientState(Config config)
        {
            Config = config;
            _defaultInterceptors = new[]
            {
                new AddAuthenticationHeadersInterceptor(config, this),
                config.IsLoggerEnabled ? new LoggerInterceptor(config) : NullRequestInterceptor.Instance 
            };
        }

        

        public async Task AuthorizeAsync(CancellationToken cancellationToken)
        {
            var pair = Config.GetApiUsernamePassword();

            var requestBody = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", pair.Username},
                {"password", pair.Password}
            };

            var message = await HttpClient.PostAsync(Config.AuthUri, new FormUrlEncodedContent(requestBody), cancellationToken).ConfigureAwait(false);
            var json = await message.Content.ReadAsStringAsync().ConfigureAwait(false);

            var authResponse = JsonConvert.DeserializeObject<AuthResposne>(json);

            AccessToken = authResponse.Access_Token;
            RenewTokenBefore = DateTime.UtcNow.AddSeconds(authResponse.Expires_In);
        }

        public Task<Response<T>> ExecutePostAsync<T>(string resourceName, T dto, CancellationToken cancellationToken) => ExecutePostAsync<T, T>(resourceName, dto, cancellationToken);


        public async Task<Response<TResponse>> ExecutePostAsync<TDto, TResponse>(string relativeUri, TDto dto, CancellationToken cancellationToken)
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(relativeUri);
            var requestBody = JsonConvert.SerializeObject(dto);
            var request = new HttpRequestMessage(HttpMethod.Post, resourceUri)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };
            return await ExecuteAndDeserialize<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<T>> ExecutePutAsync<T>(string resourceName, T dto, CancellationToken cancellationToken) where T : IIdentifierModel
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(resourceName);
            var requestBody = JsonConvert.SerializeObject(dto);
            var itemUri = resourceUri.AddSegment(dto.Id);
            var request = new HttpRequestMessage(HttpMethod.Put, itemUri)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };
            return await ExecuteAndDeserialize<T>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<T[]>> ExecuteGetAllAsync<T>(string resourceName, CancellationToken cancellationToken) where T : IIdentifierModel
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(resourceName);
            var request = new HttpRequestMessage(HttpMethod.Get, resourceUri);
            return await ExecuteAndDeserialize<T[]>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<T[]>> ExecuteGetAsync<T>(string resourceName, string queryString, CancellationToken cancellationToken) where T : IIdentifierModel
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(resourceName);
            var request = new HttpRequestMessage(HttpMethod.Get, resourceUri + "?" + queryString);
            return await ExecuteAndDeserialize<T[]>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<T>> ExecuteGetByIdAsync<T>(string resourceName, Guid id, CancellationToken cancellationToken) where T : IIdentifierModel
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(resourceName);
            var itemUri = resourceUri.AddSegment(id);
            var request = new HttpRequestMessage(HttpMethod.Get, itemUri);
            return await ExecuteAndDeserialize<T>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response> ExecuteDeleteAsync(string resourceName, Guid id, CancellationToken cancellationToken)
        {
            var resourceUri = Config.ApiBaseUriVersioned.AddSegment(resourceName);
            var itemUri = resourceUri.AddSegment(id);

            var request = new HttpRequestMessage(HttpMethod.Delete, itemUri);
            return await ExecuteAndDeserialize(request, cancellationToken).ConfigureAwait(false);
        }

        internal async Task EnsureAuthorizedAsync(CancellationToken cancellationToken)
        {
            if (AccessToken == null || RenewTokenBefore < DateTime.UtcNow)
            {
                await AuthorizeAsync(cancellationToken);
            }
        }
        private async Task<Response<T>> ExecuteAndDeserialize<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await Execute(request, cancellationToken);

            var body = await response.Content.ReadAsStringAsync();
            var result = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(body) : default(T);
            return new Response<T>
            {
                HttpStatusCode = response.StatusCode,
                ResponseBody = body,
                Result = result
            };
        }

        private async Task<Response> ExecuteAndDeserialize(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await Execute(request, cancellationToken);

            var body = await response.Content.ReadAsStringAsync();
            return new Response
            {
                HttpStatusCode = response.StatusCode,
                ResponseBody = body
            };
        }

        private async Task<HttpResponseMessage> Execute(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var interceptors = _defaultInterceptors.Union(Config.RequestInterceptors).ToArray();
            foreach (var interceptor in interceptors)
            {
                await interceptor.OnBeforeSendAsync(request, cancellationToken);
            }

            var response = await HttpClient.SendAsync(request, cancellationToken);

            foreach (var interceptor in interceptors)
            {
                await interceptor.OnResponseReceivedAsync(response, cancellationToken);
            }
            return response;
        }

        private class AuthResposne
        {
            public string Access_Token { get; set; }
            public string Token_Type { get; set; }
            public int Expires_In { get; set; }
        }
    }
}