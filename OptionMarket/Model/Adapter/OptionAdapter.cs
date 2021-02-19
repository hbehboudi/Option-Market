using OptionMarket.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OptionMarket.Model.Adapter
{
    internal class OptionAdapter
    {
        public Option Create(DataRow row, List<Stock> stocks)
        {
            var name = row[ConstValues.NameColumn].ToString();
            var description = row[ConstValues.DescriptionColumn].ToString();

            if (!IsOption(name, description))
            {
                return null;
            }

            var stockBase = stocks.First(x => description.Contains(x.Name));

            var firstSeparator = description.IndexOf('-');
            var secondSeparator = description.LastIndexOf('-');
            var length = secondSeparator - firstSeparator - 1;

            return new Option
            {
                Name = name,
                Description = description,
                stock = stocks.First(x => description.Contains(x.Name)),
                Volume = row[ConstValues.VolumeColumn].ConvertToLong(),
                DueDate = description.Substring(secondSeparator + 1),
                Price = row[ConstValues.PriceColumn].ConvertToLong(),
                PriceApply = description.Substring(firstSeparator + 1, length).ConvertToLong(),
                BuyVolume = row[ConstValues.BuyVolumeColumn].ConvertToLong(),
                BuyPrice = row[ConstValues.BuyPriceColumn].ConvertToLong(),
                SellPrice = row[ConstValues.SellPriceColumn].ConvertToLong(),
                SellVolume = row[ConstValues.SellVolumeColumn].ConvertToLong(),
            };
        }

        private static bool IsOption(string name, string description)
        {
            if (!name.StartsWith("ض") && !name.StartsWith("ط"))
            {
                return false;
            }

            if (!description.Contains('-'))
            {
                return false;
            }

            var firstSeparator = description.IndexOf('-');
            var secondSeparator = description.LastIndexOf('-');

            return firstSeparator != secondSeparator;
        }
    }
}
