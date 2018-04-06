using System.Net;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using SnelStart.B2B.Client;
using SnelStart.B2B.Client.Operations;

namespace SnelStart.B2B.Client.IntegrationTest
{
    [TestFixture]
    public class RelatieInkoopboekingenIntegrationTest
    {
        private B2BClient _client;

        [SetUp]
        public void Setup()
        {
            _client = DependencyRoot.Client;
        }

        [Test]
        public async Task GetAsync()
        {
            var relatie = await GetRelatieOrInconclusiveAsync();

            var response = await _client.RelatieInkoopboekingen.GetAllAsync(relatie.Id);

            Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        private async Task<RelatieModel> GetRelatieOrInconclusiveAsync()
        {
            var response = await _client.Relaties.GetAsync("$top=1");
            var relatie = response.Result.FirstOrDefault();

            if (relatie == null)
            {
                Assert.Inconclusive("No relatie available");
            }
            return relatie;
        }
    }
}