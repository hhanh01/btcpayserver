#if ALTCOINS
using System.Collections.Generic;
using System.Linq;
using BTCPayServer.Abstractions.Contracts;
using BTCPayServer.Client.Models;

namespace BTCPayServer.Services.Altcoins.Pirate.Services
{
    public class PirateSyncSummaryProvider : ISyncSummaryProvider
    {
        private readonly PirateRPCProvider _pirateRpcProvider;

        public PirateSyncSummaryProvider(PirateRPCProvider pirateRpcProvider)
        {
            _pirateRpcProvider = pirateRpcProvider;
        }

        public bool AllAvailable()
        {
            return _pirateRpcProvider.Summaries.All(pair => pair.Value.WalletAvailable);
        }

        public string Partial { get; } = "Pirate/PirateSyncSummary";
        public IEnumerable<ISyncStatus> GetStatuses()
        {
            return _pirateRpcProvider.Summaries.Select(pair => new PirateSyncStatus()
            {
                Summary = pair.Value, CryptoCode = pair.Key
            });
        }
    }

    public class PirateSyncStatus: SyncStatus, ISyncStatus
    {
        public override bool Available
        {
            get
            {
                return Summary?.WalletAvailable ?? false;
            }
        }

        public PirateRPCProvider.PirateLikeSummary Summary { get; set; }
    }
}
#endif
