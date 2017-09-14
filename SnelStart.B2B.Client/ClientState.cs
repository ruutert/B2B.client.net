using System;
using System.Net.Http;
using System.Threading.Tasks;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client
{
    internal class ClientState : IDisposable
    {
        public HttpClient HttpClient { get; }
        private readonly IAuthenticationOperations _authentication;

        public Config Config { get; }
        public string AccessToken { get; internal set; }

        public ClientState(Config config)
        {
            Config = config;
            HttpClient = new HttpClient();

            _authentication = new AuthenticationOperations(this);
        }

        public async Task AuthorizeAsync()
        {
            var pair = Config.GetApiUsernamePassword();

            var clientStateAccessToken = await _authentication.LoginAsync(pair.Username, pair.Password).ConfigureAwait(false);
            AccessToken = clientStateAccessToken.AccessToken;

            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
            HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Config.SubscriptionKey);
        }


        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}