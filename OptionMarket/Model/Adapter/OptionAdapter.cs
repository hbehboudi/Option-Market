using OptionMarket.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OptionMarket.Model.Adapter
{
    internal class OptionAdapter
    {
        private readonly List<Stock> stocks;

        public OptionAdapter(List<Stock> stocks) => this.stocks = stocks;

        public Option Create(DataRow row)
        {
            var name = row[ConstValues.NameColumn].ToString();
            var description = row[ConstValues.DescriptionColumn].ToString();

            if (!IsOption(name, description))
            {
                return null;
            }

            var firstSeparator = description.IndexOf(ConstValues.Separator);
            var secondSeparator = description.LastIndexOf(ConstValues.Separator);
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
            if (!name.StartsWith(ConstValues.BuyFirstLetter) && !name.StartsWith(ConstValues.SellFirstLetter))
            {
                return false;
            }

            if (!description.Contains(ConstValues.Separator))
            {
                return false;
            }

            var firstSeparator = description.IndexOf(ConstValues.Separator);
            var secondSeparator = description.LastIndexOf(ConstValues.Separator);

            return firstSeparator != secondSeparator;
        }
    }
}
