using Newtonsoft.Json;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC.Models
{
    public partial class Peer
    {
        [JsonProperty("info")] public Info Info { get; set; }
    }
}
