namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "StatusId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "LocationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "JobFunctionId", c => c.Guid(nullable: false));
            AddForeignKey("dbo.Employees", "StatusId", "dbo.EmployeeStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "StatusId", "dbo.EmployeeStatus");
            DropColumn("dbo.Employees", "JobFunctionId");
            DropColumn("dbo.Employees", "LocationId");
            DropColumn("dbo.Employees", "StatusId");
        }
    }
}
