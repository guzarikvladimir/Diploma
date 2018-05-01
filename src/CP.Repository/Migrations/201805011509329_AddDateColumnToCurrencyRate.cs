namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnToCurrencyRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyRates", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrencyRates", "Date");
        }
    }
}
