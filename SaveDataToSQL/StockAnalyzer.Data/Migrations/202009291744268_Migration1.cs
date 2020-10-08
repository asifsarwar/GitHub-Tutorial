namespace StockAnalyzer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        CompanyName = c.String(),
                        Exchange = c.String(),
                        Industry = c.String(),
                        Website = c.String(),
                        Description = c.String(),
                        CEO = c.String(),
                        IssueType = c.String(),
                        Sector = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ticker = c.String(),
                        TradeDate = c.DateTime(nullable: false),
                        Open = c.Decimal(precision: 18, scale: 2),
                        High = c.Decimal(precision: 18, scale: 2),
                        Low = c.Decimal(precision: 18, scale: 2),
                        Close = c.Decimal(precision: 18, scale: 2),
                        Volume = c.Int(nullable: false),
                        Change = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChangePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockPrices");
            DropTable("dbo.Companies");
        }
    }
}
