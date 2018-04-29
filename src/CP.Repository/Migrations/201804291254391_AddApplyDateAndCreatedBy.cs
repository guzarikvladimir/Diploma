namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplyDateAndCreatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompensationPromotions", "ApplyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CompensationPromotions", "CreatedById", c => c.Guid(nullable: false));
            AddColumn("dbo.CompensationPromotions", "CreatedDate", c => c.DateTime(nullable: false));
            AddForeignKey("dbo.CompensationPromotions", "CreatedById", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompensationPromotions", "CreatedById", "dbo.Employees");
            DropColumn("dbo.CompensationPromotions", "CreatedDate");
            DropColumn("dbo.CompensationPromotions", "CreatedById");
            DropColumn("dbo.CompensationPromotions", "ApplyDate");
        }
    }
}
