using OptionMarket.Model;
using System.Collections.Generic;
using System.IO;

namespace OptionMarket
{
    internal class CsvExporter
    {
        public void Export(string path, List<Option> options)
        {
            var streamWriter = new StreamWriter(path);

            streamWriter.WriteLine(ConstValues.Header);

            foreach (var option in options)
            {
                streamWriter.WriteLine(option);
            }

            streamWriter.Flush();
        }
    }
}
