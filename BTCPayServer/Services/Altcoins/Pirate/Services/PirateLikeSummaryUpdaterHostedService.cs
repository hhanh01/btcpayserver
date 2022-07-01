#if ALTCOINS
using System;
using System.Threading;
using System.Threading.Tasks;
using BTCPayServer.Logging;
using BTCPayServer.Services.Altcoins.Pirate.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BTCPayServer.Services.Altcoins.Pirate.Services
{
    public class PirateLikeSummaryUpdaterHostedService : IHostedService
    {
        private readonly PirateRPCProvider _PirateRpcProvider;
        private readonly PirateLikeConfiguration _pirateLikeConfiguration;

        public Logs Logs { get; }

        private CancellationTokenSource _Cts;
        public PirateLikeSummaryUpdaterHostedService(PirateRPCProvider pirateRpcProvider, PirateLikeConfiguration pirateLikeConfiguration, Logs logs)
        {
            _PirateRpcProvider = pirateRpcProvider;
            _pirateLikeConfiguration = pirateLikeConfiguration;
            Logs = logs;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _Cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            foreach (var pirateLikeConfigurationItem in _pirateLikeConfiguration.PirateLikeConfigurationItems)
            {
                _ = StartLoop(_Cts.Token, pirateLikeConfigurationItem.Key);
            }
            return Task.CompletedTask;
        }

        private async Task StartLoop(CancellationToken cancellation, string cryptoCode)
        {
            Logs.PayServer.LogInformation($"Starting listening Pirate-like daemons ({cryptoCode})");
            try
            {
                while (!cancellation.IsCancellationRequested)
                {
                    try
                    {
                        await _PirateRpcProvider.UpdateSummary(cryptoCode);
                        if (_PirateRpcProvider.IsAvailable(cryptoCode))
                        {
                            await Task.Delay(TimeSpan.FromMinutes(1), cancellation);
                        }
                        else
                        {
                            await Task.Delay(TimeSpan.FromSeconds(10), cancellation);
                        }
                    }
                    catch (Exception ex) when (!cancellation.IsCancellationRequested)
                    {
                        Logs.PayServer.LogError(ex, $"Unhandled exception in Summary updater ({cryptoCode})");
                        await Task.Delay(TimeSpan.FromSeconds(10), cancellation);
                    }
                }
            }
            catch when (cancellation.IsCancellationRequested) { }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _Cts?.Cancel();
            return Task.CompletedTask;
        }
    }
}
#endif
