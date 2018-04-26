namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceTableWithEnums : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompensationPromotions", "TypeId", "dbo.CompensationPromotionTypes");
            DropForeignKey("dbo.SalaryPromotions", "SalaryTypeId", "dbo.SalaryTypes");
            DropIndex("dbo.CompensationPromotions", new[] { "TypeId" });
            DropIndex("dbo.SalaryPromotions", new[] { "SalaryTypeId" });
            AddColumn("dbo.CompensationPromotions", "PromotionType", c => c.Int(nullable: false));
            AddColumn("dbo.SalaryPromotions", "SalaryType", c => c.Int(nullable: false));
            DropColumn("dbo.CompensationPromotions", "TypeId");
            DropColumn("dbo.SalaryPromotions", "SalaryTypeId");
            DropTable("dbo.CompensationPromotionTypes");
            DropTable("dbo.SalaryTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SalaryTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompensationPromotionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SalaryPromotions", "SalaryTypeId", c => c.Guid(nullable: false));
            AddColumn("dbo.CompensationPromotions", "TypeId", c => c.Guid(nullable: false));
            DropColumn("dbo.SalaryPromotions", "SalaryType");
            DropColumn("dbo.CompensationPromotions", "PromotionType");
            CreateIndex("dbo.SalaryPromotions", "SalaryTypeId");
            CreateIndex("dbo.CompensationPromotions", "TypeId");
            AddForeignKey("dbo.SalaryPromotions", "SalaryTypeId", "dbo.SalaryTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompensationPromotions", "TypeId", "dbo.CompensationPromotionTypes", "Id", cascadeDelete: true);
        }
    }
}
