namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Portal.Articles", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Portal.Articles", "Description");
        }
    }
}
