using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class InkoopfacturenOperations : CrudOperationsBase<InkoopfactuurModel>, IInkoopfacturenOperations
    {
        public InkoopfacturenOperations(ClientState clientState) : base(clientState, InkoopfactuurModel.ResourceName)
        {
        }

        public Task<Response<InkoopfactuurModel[]>> GetAsync(string queryString) => GetAsync(queryString, CancellationToken.None);
        public Task<Response<InkoopfactuurModel[]>> GetAsync(string queryString, CancellationToken cancellationToken) => ClientState.ExecuteGetAsync<InkoopfactuurModel>(ResourceName, queryString, cancellationToken);
    }
}