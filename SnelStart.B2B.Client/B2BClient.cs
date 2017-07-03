using System;
using System.Threading.Tasks;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client
{
    public class B2BClient : IB2BClient
    {
        private readonly ClientState _clientState;

        public IAuthenticationOperations Authentication { get; }

        public B2BClient(Config config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            _clientState = new ClientState(config);
            Authentication = new AuthenticationOperations(_clientState);
        }

        public async Task AuthorizeAsync()
        {
            var pair = _clientState.Config.GetApiUsernamePassword();

            _clientState.AccessToken = await Authentication.LoginAsync(pair.Username, pair.Password);
        }

        public void Dispose()
        {
            _clientState.Dispose();
        }
    }
}
