using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace StockAnalyzer.Data
{
    public class StockAnalyzerDbContext : DbContext
    {
        public StockAnalyzerDbContext() : base(Utility.GetConnectionString("LocalInstanceConn"))
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockAnalyzerDbContext, StockAnalyzer.Data.Migrations.Configuration>());
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
