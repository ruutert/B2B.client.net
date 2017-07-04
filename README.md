# B2B.client.net
SnelStart B2B API .NET client

# Example
```csharp
var koppelSleutel = "";
var subscriptionKey = "";
var config = new Config(subscriptionKey, koppelSleutel);
var client = new B2BClient(Config);

await Client.AuthorizeAsync();

var kostenplaatsen = await client.Kostenplaatsen.GetAllAsync();
````