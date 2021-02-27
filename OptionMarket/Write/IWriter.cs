using OptionMarket.Model;
using System.Collections.Generic;

namespace OptionMarket.Write
{
    internal interface IWriter
    {
        public void Write(string path, List<Option> options);
    }
}
