using System;
using System.Net.Http;

namespace SnelStart.B2B.Client
{
    internal class ClientState : IDisposable
    {
        public ClientState(Config config)
        {
            Config = config;
            HttpClient = new HttpClient();
        }

        public Config Config { get; }
        public string AccessToken { get; internal set; }
        public HttpClient HttpClient { get; }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}