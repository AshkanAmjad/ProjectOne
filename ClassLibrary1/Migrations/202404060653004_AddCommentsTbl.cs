namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Portal.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("Portal.Articles", t => t.ArticleId, cascadeDelete: false)
                .ForeignKey("Security.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Portal.Comments", "UserId", "Security.Users");
            DropForeignKey("Portal.Comments", "ArticleId", "Portal.Articles");
            DropIndex("Portal.Comments", new[] { "ArticleId" });
            DropIndex("Portal.Comments", new[] { "UserId" });
            DropTable("Portal.Comments");
        }
    }
}
