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
        
        public Task<Response<T>> CreateAsync(Guid parentId, T dto) => ClientState.ExecutePostAsync(string.Format(ResourceName, parentId), dto);
        public Task<Response<T>> UpdateAsync(Guid parentId, T dto) => ClientState.ExecutePutAsync(string.Format(ResourceName, parentId), dto);
        public Task<Response<T>> GetByIdAsync(Guid parentId, Guid id) => ClientState.ExecuteGetByIdAsync<T>(string.Format(ResourceName, parentId), id);
        public Task<Response> DeleteAsync(Guid parentId, Guid id) => ClientState.ExecuteDeleteAsync(string.Format(ResourceName, parentId), id);
        public Task<Response> DeleteAsync(Guid parentId, T dto) => ClientState.ExecuteDeleteAsync(string.Format(ResourceName, parentId), dto.Id);
    }
}