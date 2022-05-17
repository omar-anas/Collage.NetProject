namespace imdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j89 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.fav_act",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        iduser = c.Int(nullable: false),
                        idact = c.Int(nullable: false),
                        Actor_id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.actors", t => t.Actor_id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Actor_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.fav_dir",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        iduser = c.Int(nullable: false),
                        iddir = c.Int(nullable: false),
                        Director_id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directors", t => t.Director_id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Director_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.fav_mov",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        iduser = c.Int(nullable: false),
                        idmov = c.Int(nullable: false),
                        Movie_id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.movies", t => t.Movie_id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Movie_id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fav_mov", "User_Id", "dbo.Users");
            DropForeignKey("dbo.fav_mov", "Movie_id", "dbo.movies");
            DropForeignKey("dbo.fav_dir", "User_Id", "dbo.Users");
            DropForeignKey("dbo.fav_dir", "Director_id", "dbo.directors");
            DropForeignKey("dbo.fav_act", "User_Id", "dbo.Users");
            DropForeignKey("dbo.fav_act", "Actor_id", "dbo.actors");
            DropIndex("dbo.fav_mov", new[] { "User_Id" });
            DropIndex("dbo.fav_mov", new[] { "Movie_id" });
            DropIndex("dbo.fav_dir", new[] { "User_Id" });
            DropIndex("dbo.fav_dir", new[] { "Director_id" });
            DropIndex("dbo.fav_act", new[] { "User_Id" });
            DropIndex("dbo.fav_act", new[] { "Actor_id" });
            DropTable("dbo.fav_mov");
            DropTable("dbo.fav_dir");
            DropTable("dbo.fav_act");
        }
    }
}
