#if ALTCOINS
using System;
using System.Collections.Generic;

namespace BTCPayServer.Services.Altcoins.Pirate.Configuration
{
    public class PirateLikeConfiguration
    {
        public Dictionary<string, PirateLikeConfigurationItem> PirateLikeConfigurationItems { get; set; } =
            new Dictionary<string, PirateLikeConfigurationItem>();
    }

    public class PirateLikeConfigurationItem
    {
        public Uri DaemonRpcUri { get; set; }
        public Uri InternalWalletRpcUri { get; set; }
        public string WalletDirectory { get; set; }
    }
}
#endif
