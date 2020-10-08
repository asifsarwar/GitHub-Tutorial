
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyRepository _company;
        private StockPriceRepository _stockPrice;
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _company = new CompanyRepository(context);
            _stockPrice = new StockPriceRepository(context);
        }
        public CompanyRepository Companies
        {
            get
            {
                return _company;
            }
        }
        public StockPriceRepository StockPrices
        {
            get
            {
                return _stockPrice;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
