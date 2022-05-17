namespace imdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d451 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actors", "FirstName", c => c.String());
            AddColumn("dbo.actors", "LastName", c => c.String());
            AddColumn("dbo.actors", "age", c => c.String());
            AddColumn("dbo.directors", "FirstName", c => c.String());
            AddColumn("dbo.directors", "LastName", c => c.String());
            AddColumn("dbo.directors", "photo", c => c.String());
            AddColumn("dbo.directors", "age", c => c.String());
            DropColumn("dbo.actors", "name");
            DropColumn("dbo.directors", "name");
            DropColumn("dbo.directors", "phoro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.directors", "phoro", c => c.String());
            AddColumn("dbo.directors", "name", c => c.String());
            AddColumn("dbo.actors", "name", c => c.String());
            DropColumn("dbo.directors", "age");
            DropColumn("dbo.directors", "photo");
            DropColumn("dbo.directors", "LastName");
            DropColumn("dbo.directors", "FirstName");
            DropColumn("dbo.actors", "age");
            DropColumn("dbo.actors", "LastName");
            DropColumn("dbo.actors", "FirstName");
        }
    }
}
