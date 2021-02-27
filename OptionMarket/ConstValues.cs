using Microsoft.Extensions.Configuration;
using System;

namespace OptionMarket
{
    internal class ConstValues
    {
        public static IConfigurationRoot configuration = 
            new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        public static string InputPath = configuration.GetValue<string>("InputPath");
        public static string OutputPath = configuration.GetValue<string>("OutputPath");

        public static string XlsxExtension = configuration.GetValue<string>("XlsxExtension");
        public static string CsvExtension = configuration.GetValue<string>("CsvExtension");

        public static string OptionString = configuration.GetValue<string>("OptionString");
        public static string BuyFirstLetter = configuration.GetValue<string>("BuyFirstLetter");
        public static string SellFirstLetter = configuration.GetValue<string>("SellFirstLetter");

        public static string Separator = configuration.GetValue<string>("Separator");

        public static string Header = configuration.GetValue<string>("Header");

        public const int FirstRow = 3;

        public const int NameColumn = 0;
        public const int DescriptionColumn = 1;
        public const int VolumeColumn = 3;
        public const int PriceColumn = 7;
        public const int FinalPriceColumn = 10;
        public const int BuyVolumeColumn = 18;
        public const int BuyPriceColumn = 19;
        public const int SellPriceColumn = 20;
        public const int SellVolumeColumn = 21;
    }
}
