using System.Collections.Generic;
using Newtonsoft.Json;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC.Models
{
    public partial class SyncInfoResponse
    {
        [JsonProperty("height")] public long Height { get; set; }
    }
}
