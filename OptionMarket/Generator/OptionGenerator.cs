using OptionMarket.Extensions;
using OptionMarket.Model;
using OptionMarket.Model.Adapter;
using System.Collections.Generic;
using System.Data;

namespace OptionMarket.Generator
{
    internal class OptionGenerator
    {
        public List<Option> Generate(DataTable table)
        {
            var stocks = new StockGenerator().Generate(table);
            var options = new List<Option>();

            for (var i = ConstValues.FirstRow; i < table.Rows.Count; i++)
            {
                var option = new OptionAdapter().Create(table.Rows[i], stocks);
                options.AddIfNotNull(option);
            }

            return options;
        }
    }
}
