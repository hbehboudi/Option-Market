using OptionMarket.Generator;
using System.Text;
using System.IO;
using OptionMarket.Read;
using System.Data;
using OptionMarket.Write.Factory;
using System.Collections.Generic;
using OptionMarket.Model;

namespace OptionMarket
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var table = ReadDataTable();
            var options = new OptionGenerator().Generate(table);
            WriteOptions(options);
        }

        private static DataTable ReadDataTable()
        {
            var inputPath = ConstValues.InputPath;
            var fileExtension = new FileInfo(inputPath).Extension;
            return new ReaderFactory().Create(fileExtension).Read(inputPath);
        }

        private static void WriteOptions(List<Option> options)
        {
            var outputPath = ConstValues.OutputPath;
            var fileExtension = new FileInfo(outputPath).Extension;
            new WriterFactory().Create(fileExtension).Write(outputPath, options);
        }
    }
}
