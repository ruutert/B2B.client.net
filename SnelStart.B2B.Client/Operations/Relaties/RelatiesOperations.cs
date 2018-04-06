using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class RelatiesOperations : CrudOperationsBase<RelatieModel>, IRelatiesOperations
    {
        public RelatiesOperations(ClientState clientState)
            : base(clientState, RelatieModel.ResourceName)
        { }

        public Task<Response<RelatieModel[]>> GetAllAsync() => GetAllAsync(CancellationToken.None);
        public Task<Response<RelatieModel[]>> GetAllAsync(CancellationToken cancellationToken) => ClientState.ExecuteGetAllAsync<RelatieModel>(ResourceName, cancellationToken);

        public Task<Response<RelatieModel[]>> GetAsync(string queryString) => GetAsync(queryString, CancellationToken.None);
        public Task<Response<RelatieModel[]>> GetAsync(string queryString, CancellationToken cancellationToken) => ClientState.ExecuteGetAsync<RelatieModel>(ResourceName, queryString, cancellationToken);
    }
}