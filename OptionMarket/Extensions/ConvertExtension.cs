using System;

namespace OptionMarket.Extensions
{
    internal static class ConvertExtension
    {
        public static long ToLong(this object obj) => Convert.ToInt64(obj);
    }
}
