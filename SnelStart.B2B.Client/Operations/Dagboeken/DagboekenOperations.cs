using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class DagboekenOperations : IDagboekenOperations
    {
        private readonly ClientState _clientState;
        public const string ResourceName = DagboekModel.ResourceName;

        public DagboekenOperations(ClientState clientState)
        {
            _clientState = clientState;
        }

        public Task<Response<DagboekModel[]>> GetAllAsync() => GetAllAsync(CancellationToken.None);
        public Task<Response<DagboekModel[]>> GetAllAsync(CancellationToken cancellationToken) => _clientState.ExecuteGetAllAsync<DagboekModel>(ResourceName, cancellationToken);

    }
}