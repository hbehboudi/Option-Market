using OptionMarket.Exception;

namespace OptionMarket.Read
{
    internal class ReaderFactory
    {
        public IReader Create(string extension)
        {
            if (extension == ConstValues.XlsxExtension)
            {
                return new ExcelReader();
            }

            throw new NotImplementedReaderException();
        }
    }
}
