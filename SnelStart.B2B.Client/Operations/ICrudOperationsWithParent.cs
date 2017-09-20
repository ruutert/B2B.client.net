using System;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface ICrudOperationsWithParent<T>
    {
        Task<Response<T>> CreateWithParentAsync(T dto, Guid parentId);
        Task<Response<T>> UpdateWithParentAsync(T dto, Guid parentId);
        Task<Response<T>> GetByIdWithParentAsync(Guid id, Guid parentId);
        Task<Response> DeleteAsync(Guid id, Guid parentId);
        Task<Response> DeleteAsync(T dto, Guid parentId);
    }
}