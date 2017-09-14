using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class VerkoopboekingBijlagesOperations : CrudOperationsBase<VerkoopBoekingBijlageContentModel>,
        IVerkoopboekingBijlagesOperations
    {
        public VerkoopboekingBijlagesOperations(ClientState clientState)
            : base(clientState, VerkoopBoekingBijlageModel.ResourceName)
        { }   

        public Task<Response<VerkoopBoekingBijlageContentModel[]>> GetAllAsync() => ClientState.ExecuteGetAllAsync<VerkoopBoekingBijlageContentModel>(ResourceName);
        public Task<Response<VerkoopBoekingBijlageContentModel[]>> GetAsync(string queryString) => ClientState.ExecuteGetAsync<VerkoopBoekingBijlageContentModel>(ResourceName, queryString);
    }
}