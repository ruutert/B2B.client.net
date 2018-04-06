using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class GrootboekenOperations : CrudOperationsBase<GrootboekModel>, IGrootboekenOperations
    {
        public GrootboekenOperations(ClientState clientState)
            : base(clientState, GrootboekModel.ResourceName)
        { }

        public Task<Response<GrootboekModel[]>> GetAllAsync() => GetAllAsync(CancellationToken.None);
        public Task<Response<GrootboekModel[]>> GetAllAsync(CancellationToken cancellationToken) => ClientState.ExecuteGetAllAsync< GrootboekModel>(ResourceName, cancellationToken);
        public Task<Response<GrootboekModel[]>> GetAsync(string queryString) => GetAsync(queryString, CancellationToken.None);
        public Task<Response<GrootboekModel[]>> GetAsync(string queryString, CancellationToken cancellationToken) => ClientState.ExecuteGetAsync<GrootboekModel>(ResourceName, queryString, cancellationToken);
    }
}