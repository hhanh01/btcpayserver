using Newtonsoft.Json;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC.Models
{
    public partial class CreateAccountRequest
    {
        [JsonProperty("label")] public string Label { get; set; }
    }
}
