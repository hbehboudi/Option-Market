using ExcelDataReader;
using OptionMarket.Generator;
using System.IO;
using System.Text;

namespace OptionMarket
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var path = ConstValues.Path + ConstValues.Name;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            var table = excelReader.AsDataSet().Tables[0];

            var options = new OptionGenerator().Generate(table);

        }
    }
}
