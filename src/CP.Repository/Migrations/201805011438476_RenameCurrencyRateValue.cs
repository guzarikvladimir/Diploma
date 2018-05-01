namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCurrencyRateValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyRates", "Ratio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CurrencyRates", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CurrencyRates", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CurrencyRates", "Ratio");
        }
    }
}
