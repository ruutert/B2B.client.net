using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Interceptors
{
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
}