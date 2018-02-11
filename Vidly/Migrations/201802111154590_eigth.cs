namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eigth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropPrimaryKey("dbo.Genres");
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Genres", "GenreID", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "MovieID", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "GenreID");
            AddPrimaryKey("dbo.Movies", "MovieID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "GenreID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "MovieID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "GenreID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Movies", "MovieID");
            AddPrimaryKey("dbo.Genres", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "GenreID", cascadeDelete: true);
        }
    }
}
