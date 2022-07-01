namespace BTCPayServer
{
    public class PirateLikeSpecificBtcPayNetwork : BTCPayNetworkBase
    {
        public int MaxTrackedConfirmation = 10;
        public string UriScheme { get; set; }
    }
}
