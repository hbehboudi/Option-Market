using System.Text;

namespace OptionMarket.Model
{
    internal class Option : Stock
    {
        public string DueDate { get; set; }
        public long PriceApply { get; set; }
        public Stock Stock { get; set; }

        public long EffectivePrice => PriceApply + SellPrice;

        public double Lever => (double)Stock.Price / SellPrice;
        public double Incuriosity => ((double)PriceApply / (Stock.Price - SellPrice) - 1) * 100;
        public double BreakEven => ((double)EffectivePrice - Stock.Price) * 100 / Stock.Price;

        public override string ToString()
        {
            var separator = ',';
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Name).Append(separator);
            stringBuilder.Append(Description).Append(separator);
            stringBuilder.Append(Stock.Name).Append('-');
            stringBuilder.Append(Stock.Price).Append(separator);
            stringBuilder.Append(PriceApply).Append(separator);
            stringBuilder.Append(EffectivePrice).Append(separator);
            stringBuilder.Append(Price).Append(separator);
            stringBuilder.Append(Volume).Append(separator);
            stringBuilder.Append(SellPrice).Append(separator);
            stringBuilder.Append(SellVolume).Append(separator);
            stringBuilder.Append(BuyPrice).Append(separator);
            stringBuilder.Append(BuyVolume).Append(separator);
            stringBuilder.Append(Lever).Append(separator);
            stringBuilder.Append(Incuriosity).Append(separator);
            stringBuilder.Append(BreakEven);

            return stringBuilder.ToString();
        }
    }
}
