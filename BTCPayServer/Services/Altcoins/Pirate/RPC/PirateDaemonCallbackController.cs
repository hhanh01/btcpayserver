#if ALTCOINS
using BTCPayServer.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BTCPayServer.Services.Altcoins.Pirate.RPC
{
    [Route("[controller]")]
    [OnlyIfSupportAttribute("ARRR")]
    public class PirateLikeDaemonCallbackController : Controller
    {
        private readonly EventAggregator _eventAggregator;

        public PirateLikeDaemonCallbackController(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        [HttpGet("block")]
        public IActionResult OnBlockNotify(string hash, string cryptoCode)
        {
            _eventAggregator.Publish(new PirateEvent()
            {
                BlockHash = hash,
                CryptoCode = cryptoCode.ToUpperInvariant()
            });
            return Ok();
        }
        [HttpGet("tx")]
        public IActionResult OnTransactionNotify(string hash, string cryptoCode)
        {
            _eventAggregator.Publish(new PirateEvent()
            {
                TransactionHash = hash,
                CryptoCode = cryptoCode.ToUpperInvariant()
            });
            return Ok();
        }

    }
}
#endif
