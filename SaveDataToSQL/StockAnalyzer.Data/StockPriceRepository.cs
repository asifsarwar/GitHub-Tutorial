
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Data
{
    public class StockPriceRepository : BaseRepository<StockPrice>
    {
        public StockPriceRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public void InsertAll(IEnumerable<StockPrice> stockPrices)
        {
            dbSet.AddRange(stockPrices);
        }
        public IEnumerable<StockPrice> GetByTicker(string ticker)
        {
            return dbSet.Where(x => x.Ticker == ticker);
        }
    }
}
