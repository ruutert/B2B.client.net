using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class CrudOperationsBase<T> : ICrudOperations<T> where T : IIdentifierModel
    {
        protected readonly ClientState ClientState;
        protected readonly string ResourceName;

        public CrudOperationsBase(ClientState clientState, string resourceName)
        {
            ClientState = clientState;
            ResourceName = resourceName;
        }

        public Task<Response<T>> CreateAsync(T dto) => CreateAsync(dto, CancellationToken.None);
        public Task<Response<T>> CreateAsync(T dto, CancellationToken cancellationToken) => ClientState.ExecutePostAsync(ResourceName, dto, cancellationToken);
        public Task<Response<T>> UpdateAsync(T dto) => UpdateAsync(dto, CancellationToken.None);
        public Task<Response<T>> UpdateAsync(T dto, CancellationToken cancellationToken) => ClientState.ExecutePutAsync(ResourceName, dto, cancellationToken);
        public Task<Response<T>> GetByIdAsync(Guid id) => GetByIdAsync(id, CancellationToken.None);
        public Task<Response<T>> GetByIdAsync(Guid id, CancellationToken cancellationToken) => ClientState.ExecuteGetByIdAsync<T>(ResourceName, id, cancellationToken);
        public Task<Response> DeleteAsync(Guid id) => DeleteAsync(id, CancellationToken.None);
        public Task<Response> DeleteAsync(Guid id, CancellationToken cancellationToken) => ClientState.ExecuteDeleteAsync(ResourceName, id, cancellationToken);
        public Task<Response> DeleteAsync(T dto) => DeleteAsync(dto, CancellationToken.None);
        public Task<Response> DeleteAsync(T dto, CancellationToken cancellationToken) => ClientState.ExecuteDeleteAsync(ResourceName, dto.Id, cancellationToken);

    }
}