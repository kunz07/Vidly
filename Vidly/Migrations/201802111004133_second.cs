namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeID = c.Byte(nullable: false, identity: true),
                        MembershipName = c.String(),
                        MembershipDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeID);
            
            AddColumn("dbo.Customers", "MembershipTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeID");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "MembershipTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            DropColumn("dbo.Customers", "MembershipTypeID");
            DropTable("dbo.MembershipTypes");
        }
    }
}
