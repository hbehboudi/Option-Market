using System.Data;

namespace OptionMarket.Read
{
    internal interface IReader
    {
        DataTable Read(string inputPath);
    }
}
