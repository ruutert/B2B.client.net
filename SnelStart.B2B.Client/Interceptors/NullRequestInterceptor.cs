using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Interceptors
{
    internal class NullRequestInterceptor : IRequestInterceptor
    {
        private NullRequestInterceptor()
        {

        }
        public Task OnBeforeSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true); ;

        }

        public Task OnResponseReceivedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public static IRequestInterceptor Instance { get; } = new NullRequestInterceptor();
    }
}