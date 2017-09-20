using System;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal abstract class CrudOperationsWithParentBase<T> : ICrudOperationsWithParent<T> where T : IIdentifierModel
    {
        protected readonly ClientState ClientState;
        protected readonly string ResourceName;
        protected readonly string ParentResourceName;

        protected CrudOperationsWithParentBase(ClientState clientState, string parentResourceName, string resourceName)
        {
            ClientState = clientState;
            ParentResourceName = parentResourceName;
            ResourceName = resourceName;
        }
        
        public Task<Response<T>> CreateAsync(Guid parentId, T dto) => ClientState.ExecutePostAsync(GetBaseUri(parentId), dto);
        public Task<Response<T>> UpdateAsync(Guid parentId, T dto) => ClientState.ExecutePutAsync(GetBaseUri(parentId), dto);
        public Task<Response<T>> GetByIdAsync(Guid parentId, Guid id) => ClientState.ExecuteGetByIdAsync<T>(GetBaseUri(parentId), id);
        public Task<Response> DeleteAsync(Guid parentId, Guid id) => ClientState.ExecuteDeleteAsync(GetBaseUri(parentId), id);
        public Task<Response> DeleteAsync(Guid parentId, T dto) => ClientState.ExecuteDeleteAsync(GetBaseUri(parentId), dto.Id);

        protected string GetBaseUri(Guid parentId)
        {
            return $"{ParentResourceName}/{parentId}/{ResourceName}";
        }
    }
}