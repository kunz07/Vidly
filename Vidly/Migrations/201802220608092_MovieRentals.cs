namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRentals",
                c => new
                    {
                        MovieRentalsId = c.Byte(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_CustomerID = c.Byte(nullable: false),
                        Movie_MovieID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MovieRentalsId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Movie_MovieID);
            
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));

            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieRentals", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieRentals", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.MovieRentals", new[] { "Movie_MovieID" });
            DropIndex("dbo.MovieRentals", new[] { "Customer_CustomerID" });
            DropColumn("dbo.Movies", "NumberAvailable");
            DropTable("dbo.MovieRentals");
        }
    }
}
