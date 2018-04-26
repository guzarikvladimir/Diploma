namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllNecessaryEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BonusPromotions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompensationPromotions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Guid(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        TypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompensationPromotionTypes", t => t.TypeId, cascadeDelete: true);
            
            CreateTable(
                "dbo.CompensationPromotionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobFunctionPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobFunctions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                        TitleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobFunctionPositions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.JobFunctionTitles", t => t.TitleId, cascadeDelete: true);
            
            CreateTable(
                "dbo.JobFunctionTitles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaryPromotions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SalaryTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalaryTypes", t => t.SalaryTypeId, cascadeDelete: true);
            
            CreateTable(
                "dbo.SalaryTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryPromotions", "SalaryTypeId", "dbo.SalaryTypes");
            DropForeignKey("dbo.JobFunctions", "TitleId", "dbo.JobFunctionTitles");
            DropForeignKey("dbo.JobFunctions", "PositionId", "dbo.JobFunctionPositions");
            DropForeignKey("dbo.CompensationPromotions", "TypeId", "dbo.CompensationPromotionTypes");
            DropTable("dbo.SalaryTypes");
            DropTable("dbo.SalaryPromotions");
            DropTable("dbo.Locations");
            DropTable("dbo.JobFunctionTitles");
            DropTable("dbo.JobFunctions");
            DropTable("dbo.JobFunctionPositions");
            DropTable("dbo.EmployeeStatus");
            DropTable("dbo.Currencies");
            DropTable("dbo.Countries");
            DropTable("dbo.CompensationPromotionTypes");
            DropTable("dbo.CompensationPromotions");
            DropTable("dbo.BonusPromotions");
        }
    }
}
