using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class GrootboekenOperations : CrudOperationsBase<GrootboekModel>, IGrootboekenOperations
    {
        public GrootboekenOperations(ClientState clientState)
            : base(clientState, GrootboekModel.ResourceName)
        { }

        public Task<Response<GrootboekModel[]>> GetAllAsync() => ClientState.ExecuteGetAllAsync< GrootboekModel>(ResourceName);
        public Task<Response<GrootboekModel[]>> GetAsync(string queryString) => ClientState.ExecuteGetAsync<GrootboekModel>(ResourceName, queryString);
    }
}