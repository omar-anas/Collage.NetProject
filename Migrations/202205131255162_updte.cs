namespace imdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        comment = c.String(nullable: false, maxLength: 2500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.movies", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        like = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.movies", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "MovieID", "dbo.movies");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "MovieID", "dbo.movies");
            DropIndex("dbo.Likes", new[] { "MovieID" });
            DropIndex("dbo.Likes", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "MovieID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
        }
    }
}
