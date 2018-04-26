namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyRateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyRates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrencyId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CurrencyRates");
        }
    }
}
