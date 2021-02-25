using System;

namespace OptionMarket.Model
{
    internal class Stock
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long SellPrice { get; set; }
        public long SellVolume { get; set; }
        public long BuyPrice { get; set; }
        public long BuyVolume { get; set; }
        public long Price { get; set; }
        public long FinalPrice { get; set; }
        public long Volume { get; set; }

        public override bool Equals(object obj) => obj is Stock stock && Name == stock.Name;
        public override int GetHashCode() => HashCode.Combine(Name);
    }
}
