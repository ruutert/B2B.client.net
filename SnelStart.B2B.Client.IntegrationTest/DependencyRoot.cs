using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace SnelStart.B2B.Client.IntegrationTest
{
    internal class DependencyRoot
    {
        public static B2BClient Client { get; }

        static DependencyRoot()
        {
            var koppelSleutel = "";
            var subscriptionKey = "";


            if (string.IsNullOrEmpty(koppelSleutel))
            {
                Assert.Inconclusive("No koppelSleutel configured");
            }
            if (string.IsNullOrEmpty(subscriptionKey))
            {
                Assert.Inconclusive("No subscriptionKey configured");
            }

            Config = new Config(subscriptionKey, koppelSleutel);
            Config.Logger = x => Console.WriteLine(x);

            Client = new B2BClient(Config);
        }

        public static Config Config { get; }
    }
}