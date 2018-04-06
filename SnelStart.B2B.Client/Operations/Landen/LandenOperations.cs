using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class LandenOperations : ILandenOperations
    {
        private readonly ClientState _clientState;
        public const string ResourceName = LandIdentifierModel.ResourceName;

        public LandenOperations(ClientState clientState)
        {
            _clientState = clientState;
        }

        public Task<Response<LandModel[]>> GetAllAsync() => GetAllAsync(CancellationToken.None);
        public Task<Response<LandModel[]>> GetAllAsync(CancellationToken cancellationToken) => _clientState.ExecuteGetAllAsync<LandModel>(ResourceName, cancellationToken);
        public Task<Response<LandModel>> GetByIdAsync(Guid id) => GetByIdAsync(id, CancellationToken.None);
        public Task<Response<LandModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken) => _clientState.ExecuteGetByIdAsync<LandModel>(ResourceName, id, cancellationToken);
    }
}