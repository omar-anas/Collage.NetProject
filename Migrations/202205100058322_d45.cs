namespace imdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d45 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.act_in_mov",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_mov = c.Int(nullable: false),
                        id_act = c.Int(nullable: false),
                        actors_id = c.Int(),
                        movies_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.actors", t => t.actors_id)
                .ForeignKey("dbo.movies", t => t.movies_id)
                .Index(t => t.actors_id)
                .Index(t => t.movies_id);
            
            CreateTable(
                "dbo.actors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                        act_In_Mov_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                        description = c.String(),
                        id_director = c.Int(nullable: false),
                        act_In_Mov_id = c.Int(nullable: false),
                        director_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.directors", t => t.director_id)
                .Index(t => t.director_id);
            
            CreateTable(
                "dbo.directors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        phoro = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FristName = c.String(),
                        lastName = c.String(),
                        Photo = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movies", "director_id", "dbo.directors");
            DropForeignKey("dbo.act_in_mov", "movies_id", "dbo.movies");
            DropForeignKey("dbo.act_in_mov", "actors_id", "dbo.actors");
            DropIndex("dbo.movies", new[] { "director_id" });
            DropIndex("dbo.act_in_mov", new[] { "movies_id" });
            DropIndex("dbo.act_in_mov", new[] { "actors_id" });
            DropTable("dbo.Users");
            DropTable("dbo.directors");
            DropTable("dbo.movies");
            DropTable("dbo.actors");
            DropTable("dbo.act_in_mov");
        }
    }
}
