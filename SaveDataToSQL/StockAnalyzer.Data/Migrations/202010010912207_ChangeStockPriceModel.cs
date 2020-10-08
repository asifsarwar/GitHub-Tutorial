namespace StockAnalyzer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStockPriceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockPrices", "AdjClose", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StockPrices", "Change");
            DropColumn("dbo.StockPrices", "ChangePercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockPrices", "ChangePercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StockPrices", "Change", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StockPrices", "AdjClose");
        }
    }
}
