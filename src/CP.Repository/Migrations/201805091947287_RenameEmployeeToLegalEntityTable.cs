namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameEmployeeToLegalEntityTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeToLegalEntities", newName: "EmployeeLegalEntities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EmployeeLegalEntities", newName: "EmployeeToLegalEntities");
        }
    }
}
