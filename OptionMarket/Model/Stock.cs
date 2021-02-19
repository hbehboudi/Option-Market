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
        public long Volume { get; set; }
    }
}
