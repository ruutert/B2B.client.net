using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    internal class InkoopboekingenOperations : CrudOperationsBase<InkoopboekingModel>, IInkoopboekingenOperations
    {
        public InkoopboekingenOperations(ClientState clientState) : base(clientState, InkoopboekingModel.ResourceName) { }
    }
}
