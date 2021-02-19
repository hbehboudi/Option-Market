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
            var optionAdapter = new OptionAdapter(stocks);

            var options = new List<Option>();

            for (var i = ConstValues.FirstRow; i < table.Rows.Count; i++)
            {
                var option = optionAdapter.Create(table.Rows[i]);
                options.AddIfNotNull(option);
            }

            return options;
        }
    }
}
