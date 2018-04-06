using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface ICrudOperations<T>
    {
        Task<Response<T>> CreateAsync(T dto);
        Task<Response<T>> CreateAsync(T dto, CancellationToken cancellationToken);
        Task<Response<T>> UpdateAsync(T dto);
        Task<Response<T>> UpdateAsync(T dto, CancellationToken cancellationToken);
        Task<Response<T>> GetByIdAsync(Guid id);
        Task<Response<T>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(Guid id);
        Task<Response> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(T dto);
        Task<Response> DeleteAsync(T dto, CancellationToken cancellationToken);
    }
}