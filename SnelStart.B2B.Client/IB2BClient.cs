using System;
using System.Threading;
using System.Threading.Tasks;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client
{
    public interface IB2BClient : IDisposable
    {
        IKostenplaatsenOperations Kostenplaatsen { get; }
        IGrootboekenOperations Grootboeken { get; }
        ILandenOperations Landen { get; }
        IMemoriaalboekingenOperations Memoriaalboekingen { get; }
        IDagboekenOperations Dagboeken { get; }
        IRelatiesOperations Relaties { get; }
        IVerkoopboekingenOperations Verkoopboekingen { get; }
        IVerkoopboekingBijlagesOperations VerkoopboekingBijlages { get; }
        IVerkoopfacturenOperations Verkoopfacturen { get; }
        IInkoopfacturenOperations Inkoopfacturen { get; }
        IBankboekingenOperations Bankboekingen{ get; }
        IBankafschriftBestandenOperations BankafschriftBestanden { get; }
        IInkoopboekingenOperations Inkoopboekingen { get; }
        IRelatieInkoopboekingenOperations RelatieInkoopboekingen { get; }
        IInkoopBoekingBijlagesOperations InkoopboekingBijlages { get; }

        Task AuthorizeAsync();
        Task AuthorizeAsync(CancellationToken cancellationToken);
    }
}