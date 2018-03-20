using System.Threading.Tasks;
using NUnit.Framework;

namespace SnelStart.B2B.Client.IntegrationTest
{
    [TestFixture]
    public class AuthenticationOperationsTest
    {
        private B2BClient _client;
        private Config _config;

        [SetUp]
        public void Setup()
        {
            _client = DependencyRoot.Client;
            _config = DependencyRoot.Config;
        }

        [Test]
        public async Task WhenAuthorizing_ThenItShouldNotThrow()
        {
            await _client.AuthorizeAsync();

            Assert.IsNotEmpty(_client.AccessToken);
        }

        [Test]
        public async Task WhenAuthorizingTwice_ThenItShouldNotThrow()
        {
            await _client.AuthorizeAsync();
            await _client.AuthorizeAsync();

            Assert.IsNotEmpty(_client.AccessToken);
        }
    }
}
