using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface ICrudOperationsWithParent<T>
    {
        Task<Response<T>> CreateAsync(Guid parentId, T dto);
        Task<Response<T>> CreateAsync(Guid parentId, T dto, CancellationToken cancellationToken);
        Task<Response<T>> UpdateAsync(Guid parentId, T dto);
        Task<Response<T>> UpdateAsync(Guid parentId, T dto, CancellationToken cancellationToken);
        Task<Response<T>> GetByIdAsync(Guid parentId, Guid id);
        Task<Response<T>> GetByIdAsync(Guid parentId, Guid id, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(Guid parentId, Guid id);
        Task<Response> DeleteAsync(Guid parentId, Guid id, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(Guid parentId, T dto);
        Task<Response> DeleteAsync(Guid parentId, T dto, CancellationToken cancellationToken);
    }
}