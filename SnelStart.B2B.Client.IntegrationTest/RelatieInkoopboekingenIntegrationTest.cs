using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnelStart.B2B.Client.IntegrationTest
{
    [TestFixture]
    public class RelatieInkoopboekingenIntegrationTest
    {
        private B2BClient _client;
        //Set this to a valid relation id to run the test.
        private Guid relatieId = Guid.Empty;

        [SetUp]
        public void Setup()
        {
            _client = DependencyRoot.Client;
        }

        [Test]
        public async Task GetAsync()
        {
            var response = await _client.RelatieInkoopboekingen.GetAllAsync(relatieId);

            Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}