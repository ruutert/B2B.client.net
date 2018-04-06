using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface IGetAllOperationsWithParent<T>
    {
        Task<Response<T[]>> GetAllAsync(Guid parentId);
        Task<Response<T[]>> GetAllAsync(Guid parentId, CancellationToken cancellationToken);
    }
}