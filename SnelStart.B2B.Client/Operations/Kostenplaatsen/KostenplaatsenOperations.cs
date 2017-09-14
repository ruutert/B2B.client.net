using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class KostenplaatsenOperations : CrudOperationsBase<KostenplaatsModel>, IKostenplaatsenOperations
    {
        public KostenplaatsenOperations(ClientState clientState)
            : base(clientState, KostenplaatsIdentifierModel.ResourceName)
        { }

        public Task<Response<KostenplaatsModel[]>> GetAllAsync() => ClientState.ExecuteGetAllAsync<KostenplaatsModel>(ResourceName);
    }
}