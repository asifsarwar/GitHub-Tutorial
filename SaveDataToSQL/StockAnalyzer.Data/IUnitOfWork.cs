
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Data
{
    public interface IUnitOfWork
    {
        CompanyRepository Companies { get; }
        StockPriceRepository StockPrices { get; }
        void Commit();
    }
}
