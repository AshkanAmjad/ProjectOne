namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveColumnToUserTBL : DbMigration
    {
        public override void Up()
        {
            AddColumn("Security.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Security.Users", "IsActive");
        }
    }
}
