using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class RelatieInkoopboekingenOperations : IRelatieInkoopboekingenOperations
    {
        private readonly ClientState ClientState;

        public RelatieInkoopboekingenOperations(ClientState clientState)
        {
            ClientState = clientState;
        }

        public Task<Response<InkoopboekingModel[]>> GetAllAsync(Guid parentId) => GetAllAsync(parentId,
            CancellationToken.None);

        public Task<Response<InkoopboekingModel[]>> GetAllAsync(Guid parentId, CancellationToken cancellationToken)
        {
            return ClientState.ExecuteGetAllAsync<InkoopboekingModel>($"{RelatieModel.ResourceName}/{parentId}/{InkoopboekingModel.ResourceName}", cancellationToken);
        }
    }
}
