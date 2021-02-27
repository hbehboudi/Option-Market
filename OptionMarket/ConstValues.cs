namespace OptionMarket
{
    internal class ConstValues
    {
        public const string InputPath = @"C:/Users/Hossein/Downloads/MarketWatchPlus-1399_12_6.xlsx";
        public const string OutputPath = @"C:/Users/Hossein/Desktop/Output.csv";

        public const string XlsxExtension = ".xlsx";
        public const string CsvExtension = ".csv";

        public const int NameColumn = 0;
        public const int DescriptionColumn = 1;
        public const int VolumeColumn = 3;
        public const int PriceColumn = 7;
        public const int FinalPriceColumn = 10;
        public const int BuyVolumeColumn = 18;
        public const int BuyPriceColumn = 19;
        public const int SellPriceColumn = 20;
        public const int SellVolumeColumn = 21;

        public const string OptionString = "اختيار";
        public const string BuyFirstLetter = "ض";
        public const string SellFirstLetter = "ط";

        public const int FirstRow = 3;

        public const string Separator = "-";

        public const string Header = "نام,توضیحات,سهم پایه,قیمت اعمال,قیمت تمام شده,قیمت,حجم," +
            "قیمت فروش,حجم فروش,قیمت خرید,حجم خرید,اهرم,بی‌تفاوتی,سربه‌سری";
    }
}
