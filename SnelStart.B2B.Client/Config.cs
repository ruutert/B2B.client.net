using System;
using System.Text;

namespace SnelStart.B2B.Client
{
    public class Config
    {
        public Uri AuthUri => new Uri("https://auth.snelstart.nl/b2b/token");
        public Uri ApiBaseUriVersioned => new Uri("https://b2bapi.snelstart.nl/v1");
        public string SubscriptionKey { get; }
        public string KoppelSleutel { get; }

        public Config(string subscriptionKey, string koppelSleutel)
        {
            SubscriptionKey = subscriptionKey;
            KoppelSleutel = koppelSleutel;
        }

        internal UsernamePasswordPair GetApiUsernamePassword()
        {
            var decodedKoppelingSleutel = Base64Decode(KoppelSleutel);
            var koppelingKeyParts = GetKoppelingKeyParts(decodedKoppelingSleutel);

            return new UsernamePasswordPair(koppelingKeyParts[0], koppelingKeyParts[1]);
        }

        private string Base64Decode(string userKey)
        {
            var data = Convert.FromBase64String(userKey);
            var result = Encoding.UTF8.GetString(data);
            return result;
        }

        private string[] GetKoppelingKeyParts(string userKey)
        {
            var result = userKey.Split(new[] { ":" }, StringSplitOptions.None);
            return result;
        }
    }
}