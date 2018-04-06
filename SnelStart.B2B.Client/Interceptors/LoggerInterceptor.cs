using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Interceptors
{
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
}