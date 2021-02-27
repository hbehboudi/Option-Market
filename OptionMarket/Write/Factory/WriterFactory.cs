using OptionMarket.Exception;

namespace OptionMarket.Write.Factory
{
    internal class WriterFactory
    {
        public IWriter Create(string extension)
        {
            if (extension == ConstValues.CsvExtension)
            {
                return new CsvWriter();
            }

            throw new NotImplementedWriterException();
        }
    }
}
