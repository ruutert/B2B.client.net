using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Interceptors
{
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
            request.Headers.Add((string) "Ocp-Apim-Subscription-Key", (string) _config.SubscriptionKey);
        }
    }
}