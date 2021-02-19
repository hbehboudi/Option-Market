using OptionMarket.Model;
using OptionMarket.Model.Adapter;
using System.Collections.Generic;
using System.Data;

namespace OptionMarket.Generator
{
    internal class StockGenerator
    {
        public List<Stock> Generate(DataTable table)
        {
            var stocks = new List<Stock>();

            for (var i = ConstValues.FirstRow; i < table.Rows.Count; i++)
            {
                var stock = new StockAdapter().Create(table.Rows[i]);
                stocks.Add(stock);
            }

            return stocks;
        }
    }
}
