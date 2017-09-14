using System;
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

        public Task<Response<T>> CreateAsync(T dto) => ClientState.ExecutePostAsync(ResourceName, dto);
        public Task<Response<T>> UpdateAsync(T dto) => ClientState.ExecutePutAsync(ResourceName, dto);
        public Task<Response<T>> GetByIdAsync(Guid id) => ClientState.ExecuteGetByIdAsync<T>(ResourceName, id);
        public Task<Response> DeleteAsync(Guid id) => ClientState.ExecuteDeleteAsync(ResourceName, id);
        public Task<Response> DeleteAsync(T dto) => ClientState.ExecuteDeleteAsync(ResourceName, dto.Id);

    }
}