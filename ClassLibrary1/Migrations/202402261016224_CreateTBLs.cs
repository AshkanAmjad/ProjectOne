namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTBLs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Portal.ArticleCategories",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.CategoryId })
                .ForeignKey("Portal.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("Portal.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "Portal.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("Security.Users", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "Security.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "Security.UserRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Security.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Security.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Security.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "Portal.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Portal.ArticleCategories", "CategoryId", "Portal.Categories");
            DropForeignKey("Portal.ArticleCategories", "ArticleId", "Portal.Articles");
            DropForeignKey("Portal.Articles", "AuthorId", "Security.Users");
            DropForeignKey("Security.UserRoles", "UserId", "Security.Users");
            DropForeignKey("Security.UserRoles", "RoleId", "Security.Roles");
            DropIndex("Security.UserRoles", new[] { "UserId" });
            DropIndex("Security.UserRoles", new[] { "RoleId" });
            DropIndex("Portal.Articles", new[] { "AuthorId" });
            DropIndex("Portal.ArticleCategories", new[] { "CategoryId" });
            DropIndex("Portal.ArticleCategories", new[] { "ArticleId" });
            DropTable("Portal.Categories");
            DropTable("Security.Roles");
            DropTable("Security.UserRoles");
            DropTable("Security.Users");
            DropTable("Portal.Articles");
            DropTable("Portal.ArticleCategories");
        }
    }
}
