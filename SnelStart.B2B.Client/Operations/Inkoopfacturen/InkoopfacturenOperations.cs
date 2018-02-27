using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class InkoopfacturenOperations : CrudOperationsBase<InkoopfactuurModel>, IInkoopfacturenOperations
    {
        public InkoopfacturenOperations(ClientState clientState) : base(clientState, InkoopfactuurModel.ResourceName)
        {
        }

        public Task<Response<InkoopfactuurModel[]>> GetAsync(string queryString) => ClientState.ExecuteGetAsync<InkoopfactuurModel>(ResourceName, queryString);
    }
}