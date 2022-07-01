#if ALTCOINS
using BTCPayServer.Client.Models;
using BTCPayServer.Payments;
using BTCPayServer.Services.Altcoins.Pirate.Utils;
using BTCPayServer.Services.Invoices;

namespace BTCPayServer.Services.Altcoins.Pirate.Payments
{
    public class PirateLikePaymentData : CryptoPaymentData
    {
        public long Amount { get; set; }
        public string Address { get; set; }
        public long SubaddressIndex { get; set; }
        public long SubaccountIndex { get; set; }
        public long BlockHeight { get; set; }
        public long ConfirmationCount { get; set; }
        public string TransactionId { get; set; }

        public BTCPayNetworkBase Network { get; set; }

        public string GetPaymentId()
        {
            return $"{TransactionId}#{SubaccountIndex}#{SubaddressIndex}";
        }

        public string[] GetSearchTerms()
        {
            return new[] { TransactionId };
        }

        public decimal GetValue()
        {
            return PirateMoney.Convert(Amount);
        }

        public bool PaymentCompleted(PaymentEntity entity)
        {
            return ConfirmationCount >= (Network as PirateLikeSpecificBtcPayNetwork).MaxTrackedConfirmation;
        }

        public bool PaymentConfirmed(PaymentEntity entity, SpeedPolicy speedPolicy)
        {
            switch (speedPolicy)
            {
                case SpeedPolicy.HighSpeed:
                    return ConfirmationCount >= 0;
                case SpeedPolicy.MediumSpeed:
                    return ConfirmationCount >= 1;
                case SpeedPolicy.LowMediumSpeed:
                    return ConfirmationCount >= 2;
                case SpeedPolicy.LowSpeed:
                    return ConfirmationCount >= 6;
                default:
                    return false;
            }
        }

        public PaymentType GetPaymentType()
        {
            return PiratePaymentType.Instance;
        }

        public string GetDestination()
        {
            return Address;
        }
    }
}
#endif
