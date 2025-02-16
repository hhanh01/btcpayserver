using BTCPayServer.Client.JsonConverters;
using BTCPayServer.Lightning;
using Newtonsoft.Json;

namespace BTCPayServer.Client.Models
{
    public class LightningNodeBalanceData
    {
        [JsonProperty("onchain")]
        public OnchainBalanceData OnchainBalance { get; set; }
        
        [JsonProperty("offchain")]
        public OffchainBalanceData OffchainBalance { get; set; }
        
        public LightningNodeBalanceData()
        {
        }

        public LightningNodeBalanceData(OnchainBalanceData onchain, OffchainBalanceData offchain)
        {
            OnchainBalance = onchain;
            OffchainBalance = offchain;
        }
    }

    public class OnchainBalanceData
    {
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Confirmed { get; set; }
        
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Unconfirmed { get; set; }
        
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Reserved { get; set; }
    }

    public class OffchainBalanceData
    {
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Opening { get; set; }
        
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Local { get; set; }
        
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Remote { get; set; }
        
        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Closing { get; set; }
    }
}
