using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface IVerkoopfacturenOperations : IQueryOperations<VerkoopFactuurModel>
    {
        Task<Response<VerkoopFactuurModel>> GetByIdAsync(Guid id);
        Task<Response> GetUblByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}