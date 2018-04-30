namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompensationPromotionStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompensationPromotions", "PromotionStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompensationPromotions", "PromotionStatus");
        }
    }
}
