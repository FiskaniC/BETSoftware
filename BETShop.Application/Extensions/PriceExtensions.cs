using System.Globalization;

namespace BETShop.Application.Extensions
{
    public static class PriceExtensions
    {
        public static string ToTwoDecimals(this decimal number)
        {
            return number.ToString("N", new NumberFormatInfo
            {
                NumberDecimalDigits = 2
            });
        }
    }
}
