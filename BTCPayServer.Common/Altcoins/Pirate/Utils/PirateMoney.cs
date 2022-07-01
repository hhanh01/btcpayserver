using System.Globalization;

namespace BTCPayServer.Services.Altcoins.Pirate.Utils
{
    public class PirateMoney
    {
        public static decimal Convert(long zats)
        {
            var amt = zats.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0');
            amt = amt.Length == 10 ? $"0.{amt}" : amt.Insert(amt.Length - 10, ".");

            return decimal.Parse(amt, CultureInfo.InvariantCulture);
        }

        public static long Convert(decimal arrr)
        {
            return System.Convert.ToInt64(arrr * 10000000000);
        }
    }
}
