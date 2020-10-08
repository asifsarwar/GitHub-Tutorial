
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Data
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public void InsertAll(IEnumerable<Company> companies)
        {
            dbSet.AddRange(companies);
        }
        public IEnumerable<Company> GetBySymbol(string symbol)
        {
            return dbSet.Where(c => c.Symbol == symbol);
        }
        public IEnumerable<Company> GetByName(string name)
        {
            return dbSet.Where(c => c.CompanyName == name);
        }
    }
}
