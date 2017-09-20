using System;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class VerkoopboekingBijlagesOperations : CrudOperationsWithParentBase<VerkoopBoekingBijlageContentModel>,
        IVerkoopboekingBijlagesOperations
    {
        public VerkoopboekingBijlagesOperations(ClientState clientState)
            : base(clientState, VerkoopBoekingBijlageModel.ResourceName)
        { }   

        public Task<Response<VerkoopBoekingBijlageContentModel[]>> GetAllAsync(Guid parentId) => ClientState.ExecuteGetAllAsync<VerkoopBoekingBijlageContentModel>(string.Format(ResourceName, parentId));
    }
}