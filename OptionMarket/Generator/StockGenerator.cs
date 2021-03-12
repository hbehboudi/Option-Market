using OptionMarket.Extensions;
using OptionMarket.Model;
using System.Collections.Generic;
using System.Data;

namespace OptionMarket.Generator
{
    internal class StockGenerator
    {
        public List<Stock> Generate(DataTable table)
        {
            var stocks = new List<Stock>();
            
            for (var i = ConstValues.FirstRow; i < table.Rows.Count; i++)
            {
                var stock = Create(table.Rows[i]);
                stocks.Add(stock);
            }

            return stocks;
        }

        private Stock Create(DataRow row) =>
            new Stock
            {
                Name = row[ConstValues.NameColumn].ToString(),
                Description = row[ConstValues.DescriptionColumn].ToString(),
                Volume = row[ConstValues.VolumeColumn].ToLong(),
                Price = row[ConstValues.PriceColumn].ToLong(),
                FinalPrice = row[ConstValues.FinalPriceColumn].ToLong(),
                BuyVolume = row[ConstValues.BuyVolumeColumn].ToLong(),
                BuyPrice = row[ConstValues.BuyPriceColumn].ToLong(),
                SellPrice = row[ConstValues.SellPriceColumn].ToLong(),
                SellVolume = row[ConstValues.SellVolumeColumn].ToLong(),
            };
    }
}
