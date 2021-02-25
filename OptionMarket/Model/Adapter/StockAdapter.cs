using OptionMarket.Extensions;
using System.Data;

namespace OptionMarket.Model.Adapter
{
    internal class StockAdapter
    {
        public Stock Create(DataRow row) =>
            new Stock
            {
                Name = row[ConstValues.NameColumn].ToString(),
                Description = row[ConstValues.DescriptionColumn].ToString(),
                Volume = row[ConstValues.VolumeColumn].ConvertToLong(),
                Price = row[ConstValues.PriceColumn].ConvertToLong(),
                FinalPrice = row[ConstValues.FinalPriceColumn].ConvertToLong(),
                BuyVolume = row[ConstValues.BuyVolumeColumn].ConvertToLong(),
                BuyPrice = row[ConstValues.BuyPriceColumn].ConvertToLong(),
                SellPrice = row[ConstValues.SellPriceColumn].ConvertToLong(),
                SellVolume = row[ConstValues.SellVolumeColumn].ConvertToLong(),
            };
    }
}
