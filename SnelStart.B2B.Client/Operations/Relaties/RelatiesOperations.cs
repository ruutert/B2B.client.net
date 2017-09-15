using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class RelatiesOperations : CrudOperationsBase<RelatieModel>, IRelatiesOperations
    {
        public RelatiesOperations(ClientState clientState)
            : base(clientState, RelatieModel.ResourceName)
        { }

        public Task<Response<RelatieModel[]>> GetAllAsync() => ClientState.ExecuteGetAllAsync<RelatieModel>(ResourceName);
        public Task<Response<RelatieModel[]>> GetAsync(string queryString) => ClientState.ExecuteGetAsync<RelatieModel>(ResourceName, queryString);
    }
}