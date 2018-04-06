using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class KostenplaatsenOperations : CrudOperationsBase<KostenplaatsModel>, IKostenplaatsenOperations
    {
        public KostenplaatsenOperations(ClientState clientState)
            : base(clientState, KostenplaatsIdentifierModel.ResourceName)
        { }

        public Task<Response<KostenplaatsModel[]>> GetAllAsync() => GetAllAsync(CancellationToken.None);
        public Task<Response<KostenplaatsModel[]>> GetAllAsync(CancellationToken cancellationToken) => ClientState.ExecuteGetAllAsync<KostenplaatsModel>(ResourceName, cancellationToken);
    }
}