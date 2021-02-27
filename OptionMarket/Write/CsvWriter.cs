using OptionMarket.Model;
using System.Collections.Generic;
using System.IO;

namespace OptionMarket.Write
{
    internal class CsvWriter : IWriter
    {
        public void Write(string path, List<Option> options)
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
