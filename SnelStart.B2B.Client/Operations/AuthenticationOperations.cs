using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SnelStart.B2B.Client.Operations
{
    internal class AuthenticationOperations : IAuthenticationOperations
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config;

        public AuthenticationOperations(ClientState clientState)
        {
            _httpClient = clientState.HttpClient;
            _config = clientState.Config;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var requestBody = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", username},
                {"password", password}
            };

            var message = await _httpClient.PostAsync(_config.AuthUri, new FormUrlEncodedContent(requestBody));
            var json = await message.Content.ReadAsStringAsync();
            dynamic response = JObject.Parse(json);

            return new LoginResponse
            {
                AccessToken = response.access_token,
                TokenType = response.token_type,
                ExpiresIn = response.expires_in,
            };
        }
    }
}