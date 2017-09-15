namespace SnelStart.B2B.Client.IntegrationTest
{
    internal class DependencyRoot
    {
        public static B2BClient Client { get; }

        static DependencyRoot()
        {
            var koppelSleutel = "zelf invullen";
            var subscriptionKey = "zelf invullen";

            Config = new Config(subscriptionKey, koppelSleutel);
            Client = new B2BClient(Config);
        }

        public static Config Config { get; }
    }
}