using System;
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

        public Task<Response<LandModel[]>> GetAllAsync() => _clientState.ExecuteGetAllAsync<LandModel>(ResourceName);
        public Task<Response<LandModel>> GetByIdAsync(Guid id) => _clientState.ExecuteGetByIdAsync<LandModel>(ResourceName, id);
    }
}