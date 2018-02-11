namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(Name, DateOfBirth, MembershipTypeID) VALUES('Kunal', '06-29-1995', 1)");
            Sql("INSERT INTO Customers(Name, DateOfBirth, MembershipTypeID) VALUES('Dad', '06-23-1958', 4)");
            Sql("INSERT INTO Customers(Name, DateOfBirth, MembershipTypeID) VALUES('Mom', '02-10-1961', 4)");
        }
        
        public override void Down()
        {
        }
    }
}
