using System;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class CrudOperationsWithParentBase<T> : ICrudOperationsWithParent<T> where T : IIdentifierModel
    {
        protected readonly ClientState ClientState;
        protected readonly string ResourceName;

        public CrudOperationsWithParentBase(ClientState clientState, string resourceName)
        {
            ClientState = clientState;
            ResourceName = resourceName;
        }
        
        public Task<Response<T>> CreateWithParentAsync(T dto, Guid parentId) => ClientState.ExecutePostAsync(string.Format(ResourceName, parentId), dto);
        public Task<Response<T>> UpdateWithParentAsync(T dto, Guid parentId) => ClientState.ExecutePutAsync(string.Format(ResourceName, parentId), dto);
        public Task<Response<T>> GetByIdWithParentAsync(Guid id, Guid parentId) => ClientState.ExecuteGetByIdAsync<T>(string.Format(ResourceName, parentId), id);
        public Task<Response> DeleteAsync(Guid id, Guid parentId) => ClientState.ExecuteDeleteAsync(string.Format(ResourceName, parentId), id);
        public Task<Response> DeleteAsync(T dto, Guid parentId) => ClientState.ExecuteDeleteAsync(string.Format(ResourceName, parentId), dto.Id);
    }
}