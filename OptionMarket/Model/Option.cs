namespace OptionMarket.Model
{
    internal class Option : Stock
    {
        public string DueDate { get; set; }
        public long PriceApply { get; set; }
        public Stock stock { get; set; }
    }
}
