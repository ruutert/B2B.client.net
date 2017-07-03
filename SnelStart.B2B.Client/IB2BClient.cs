using System;
using System.Threading.Tasks;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client
{
    public interface IB2BClient : IDisposable
    {
        Task AuthorizeAsync();
        IAuthenticationOperations Authentication { get; }
    }
}