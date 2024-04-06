namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommentTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("Portal.Comments", "Title", c => c.String(nullable: false, maxLength: 20));
            AddColumn("Portal.Comments", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("Portal.Comments", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Portal.Comments", "IsActive");
            DropColumn("Portal.Comments", "CreateDate");
            DropColumn("Portal.Comments", "Title");
        }
    }
}
