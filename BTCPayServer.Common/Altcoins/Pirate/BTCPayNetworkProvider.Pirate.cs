using NBitcoin;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitPirate()
        {
            Add(new PirateLikeSpecificBtcPayNetwork()
            {
                CryptoCode = "XMR",
                DisplayName = "Pirate",
                Divisibility = 12,
                BlockExplorerLink =
                    NetworkType == ChainName.Mainnet
                        ? "https://www.exploremonero.com/transaction/{0}" // TODO HHH
                        : "https://testnet.xmrchain.net/tx/{0}",
                DefaultRateRules = new[]
                {
                    "XMR_X = XMR_BTC * BTC_X",
                    "XMR_BTC = kraken(XMR_BTC)"
                },
                CryptoImagePath = "/imlegacy/monero.svg",
                UriScheme = "monero"
            });
        }
    }
}
