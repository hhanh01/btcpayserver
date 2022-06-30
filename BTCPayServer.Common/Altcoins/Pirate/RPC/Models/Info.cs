using Newtonsoft.Json;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC.Models
{
    public partial class Info
    {
        [JsonProperty("height")] public long Height { get; set; }
    }
}
