namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLegalEntityFieldToCompensationPromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompensationPromotions", "LegalEntityId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompensationPromotions", "LegalEntityId");
        }
    }
}
