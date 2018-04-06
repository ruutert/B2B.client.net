using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client
{
    public class Config
    {
        private static readonly Lazy<HttpClient> DefaultHttpClientProviderInstance = new Lazy<HttpClient>(() =>
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true
            };
            return new HttpClient(handler);
        });

        private static readonly Func<HttpClient> DefaultHttpClientProvider =
            () => DefaultHttpClientProviderInstance.Value;

        private Action<string> _logger = x => { };

        public Func<HttpClient> HttpClientProvider { get; set; } = DefaultHttpClientProvider;

        public Uri AuthUri { get; }
        public Uri ApiBaseUriVersioned { get; }
        public string SubscriptionKey { get; }
        public string KoppelSleutel { get; }
        public int ConnectionLeaseTimeoutInMilliseconds { get; set; } = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
        public int DnsRefreshTimeoutInMilliseconds { get; set; } = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
        public bool ConfigureDnsRefreshTimeoutEnabled { get; set; } = true;
        public List<IRequestInterceptor> RequestInterceptors { get; } = new List<IRequestInterceptor>();

        public Action<string> Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                IsLoggerEnabled = true;
                _logger = value;
            }
        }

        public bool IsLoggerEnabled { get; private set; } = false;

        public Config(string subscriptionKey, string koppelSleutel)
            : this(
                  subscriptionKey,
                  koppelSleutel,
                  new Uri("https://auth.snelstart.nl"),
                  new Uri("https://b2bapi.snelstart.nl")
            )
        {

        }

        public Config(string subscriptionKey, string koppelSleutel, Uri authUri, Uri apiUri)
        {
            if (string.IsNullOrWhiteSpace(subscriptionKey))
            {
                throw new ArgumentException("Parameter cannot be null or whitespace", nameof(subscriptionKey));
            }

            if (string.IsNullOrWhiteSpace(koppelSleutel))
            {
                throw new ArgumentException("Parameter cannot be null or whitespace", nameof(koppelSleutel));
            }
            if (authUri == null)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(authUri));
            }

            if (apiUri == null)
            {
                throw new ArgumentException("Parameter cannot be null", nameof(apiUri));
            }

            SubscriptionKey = subscriptionKey;
            KoppelSleutel = koppelSleutel;
            AuthUri = new Uri(authUri, "b2b/token");
            ApiBaseUriVersioned = new Uri(apiUri, "v1");
        }

        internal UsernamePasswordPair GetApiUsernamePassword()
        {
            var decodedKoppelingSleutel = Base64Decode(KoppelSleutel);
            var koppelingKeyParts = GetKoppelingKeyParts(decodedKoppelingSleutel);

            return new UsernamePasswordPair(koppelingKeyParts[0], koppelingKeyParts[1]);
        }

        private string Base64Decode(string userKey)
        {
            var data = Convert.FromBase64String(userKey);
            var result = Encoding.UTF8.GetString(data);
            return result;
        }

        private string[] GetKoppelingKeyParts(string userKey)
        {
            var result = userKey.Split(new[] { ":" }, StringSplitOptions.None);
            return result;
        }

    }


    internal abstract class RequestInterceptor : IRequestInterceptor
    {
        public virtual Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnResponseReceivedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    public interface IRequestInterceptor
    {
        Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
        Task OnResponseReceivedAsync(HttpResponseMessage response, CancellationToken cancellationToken);
    }
    internal class NullRequestInterceptor : IRequestInterceptor
    {
        private NullRequestInterceptor()
        {

        }
        public Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; ;

        }

        public Task OnResponseReceivedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public static IRequestInterceptor Instance { get; } = new NullRequestInterceptor();
    }
    internal class LoggerInterceptor : RequestInterceptor
    {
        private readonly Config _config;

        public LoggerInterceptor(Config config)
        {
            _config = config;
        }

        public override async Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Request:");
            sb.AppendLine(request.ToString());
            if (request.Content != null)
            {
                sb.AppendLine(await request.Content.ReadAsStringAsync());
            }
            sb.AppendLine("");
            _config.Logger(sb.ToString());
        }

        public override async Task OnResponseReceivedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Response:");
            sb.AppendLine(response.ToString());
            if (response.Content != null)
            {
                sb.AppendLine(await response.Content.ReadAsStringAsync());
            }
            sb.AppendLine("");

            _config.Logger(sb.ToString());
        }
    }

    internal class AddAuthenticationHeadersInterceptor : RequestInterceptor
    {
        private readonly Config _config;
        private readonly ClientState _clientState;

        public AddAuthenticationHeadersInterceptor(Config config, ClientState clientState)
        {
            _config = config;
            _clientState = clientState;
        }

        public override async Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await _clientState.EnsureAuthorizedAsync(cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _clientState.AccessToken);
            request.Headers.Add("Ocp-Apim-Subscription-Key", _config.SubscriptionKey);
        }
    }
}