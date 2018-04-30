namespace CP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentFieldToCompensationPromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompensationPromotions", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompensationPromotions", "Comment");
        }
    }
}
