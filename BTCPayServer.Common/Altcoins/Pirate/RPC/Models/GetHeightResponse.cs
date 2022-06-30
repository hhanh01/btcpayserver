using Newtonsoft.Json;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC.Models
{
    public partial class GetHeightResponse
    {
        [JsonProperty("height")] public long Height { get; set; }
    }
}
