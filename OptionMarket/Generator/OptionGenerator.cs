using OptionMarket.Extensions;
using OptionMarket.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OptionMarket.Generator
{
    internal class OptionGenerator
    {
        public List<Option> Generate(DataTable table)
        {
            var stocks = new StockGenerator().Generate(table);

            var options = new List<Option>();

            for (var i = ConstValues.FirstRow; i < table.Rows.Count; i++)
            {
                var option = Create(table.Rows[i], stocks);
                options.AddIfNotNull(option);
            }

            return options;
        }

        private Option Create(DataRow row, List<Stock> stocks)
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

            var baseName = description.Substring(0, description.IndexOf(ConstValues.Separator));

            return new Option
            {
                Name = name,
                Description = description,
                Stock = stocks.Single(x => baseName[(baseName.IndexOf(" ") + 1)..].Equals(x.Name)),
                Volume = row[ConstValues.VolumeColumn].ToLong(),
                DueDate = description[(secondSeparator + 1)..],
                Price = row[ConstValues.PriceColumn].ToLong(),
                FinalPrice = row[ConstValues.FinalPriceColumn].ToLong(),
                PriceApply = description.Substring(firstSeparator + 1, length).ToLong(),
                BuyVolume = row[ConstValues.BuyVolumeColumn].ToLong(),
                BuyPrice = row[ConstValues.BuyPriceColumn].ToLong(),
                SellPrice = row[ConstValues.SellPriceColumn].ToLong(),
                SellVolume = row[ConstValues.SellVolumeColumn].ToLong(),
            };
        }

        private static bool IsOption(string name, string description)
        {
            if (!name.StartsWith(ConstValues.BuyFirstLetter) &&
                !name.StartsWith(ConstValues.SellFirstLetter))
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
