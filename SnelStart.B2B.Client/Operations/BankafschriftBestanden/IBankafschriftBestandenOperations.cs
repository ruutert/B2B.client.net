using System.Threading;
using System.Threading.Tasks;

namespace SnelStart.B2B.Client.Operations
{
    public interface IBankafschriftBestandenOperations
    {
        Task<Response<BankafschriftBestandResponse[]>> ReadBankafschriftBestandenAsync(BankafschriftBestand[] bestanden);
        Task<Response<BankafschriftBestandResponse[]>> ReadBankafschriftBestandenAsync(BankafschriftBestand[] bestanden, CancellationToken cancellationToken);
    }
}