using System;

namespace OptionMarket.Extensions
{
    internal static class ConvertExtension
    {
        public static long ConvertToLong(this object obj) => Convert.ToInt32(obj);
    }
}
