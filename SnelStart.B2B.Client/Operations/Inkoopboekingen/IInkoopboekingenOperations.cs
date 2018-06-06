using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface IInkoopboekingenOperations : ICrudOperations<InkoopboekingModel>
    {
        Task<Response<InkoopboekingModel>> UploadUblAsync(UblContentModel id, CancellationToken cancellationToken);
    }
}
