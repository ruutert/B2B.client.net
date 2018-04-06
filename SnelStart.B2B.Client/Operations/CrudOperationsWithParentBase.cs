using System;
using System.Threading;
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

        public Task<Response<T>> CreateAsync(Guid parentId, T dto) => CreateAsync(parentId, dto, CancellationToken.None);
        public Task<Response<T>> CreateAsync(Guid parentId, T dto, CancellationToken cancellationToken) => ClientState.ExecutePostAsync(GetBaseUri(parentId), dto, cancellationToken);
        public Task<Response<T>> UpdateAsync(Guid parentId, T dto) => UpdateAsync(parentId, dto, CancellationToken.None);
        public Task<Response<T>> UpdateAsync(Guid parentId, T dto, CancellationToken cancellationToken) => ClientState.ExecutePutAsync(GetBaseUri(parentId), dto, cancellationToken);
        public Task<Response<T>> GetByIdAsync(Guid parentId, Guid id) => GetByIdAsync(parentId, id, CancellationToken.None);
        public Task<Response<T>> GetByIdAsync(Guid parentId, Guid id, CancellationToken cancellationToken) => ClientState.ExecuteGetByIdAsync<T>(GetBaseUri(parentId), id, cancellationToken);
        public Task<Response> DeleteAsync(Guid parentId, Guid id) => DeleteAsync(parentId, id, CancellationToken.None);
        public Task<Response> DeleteAsync(Guid parentId, Guid id, CancellationToken cancellationToken) => ClientState.ExecuteDeleteAsync(GetBaseUri(parentId), id, cancellationToken);
        public Task<Response> DeleteAsync(Guid parentId, T dto) => DeleteAsync(parentId, dto.Id, CancellationToken.None);
        public Task<Response> DeleteAsync(Guid parentId, T dto, CancellationToken cancellationToken) => ClientState.ExecuteDeleteAsync(GetBaseUri(parentId), dto.Id, cancellationToken);

        protected string GetBaseUri(Guid parentId)
        {
            return $"{ParentResourceName}/{parentId}/{ResourceName}";
        }
    }
}