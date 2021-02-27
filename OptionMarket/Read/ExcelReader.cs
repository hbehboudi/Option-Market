using ExcelDataReader;
using System.IO;
using System.Data;

namespace OptionMarket.Read
{
    internal class ExcelReader : IReader
    {
        public DataTable Read(string inputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException();
            }

            var stream = File.Open(inputPath, FileMode.Open, FileAccess.Read);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            return excelReader.AsDataSet().Tables[0];
        }
    }
}
