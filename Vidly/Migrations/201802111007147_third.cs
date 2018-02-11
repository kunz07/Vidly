namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(MembershipName, MembershipDuration) VALUES('Pay As You Go', 0)");
            Sql("INSERT INTO MembershipTypes(MembershipName, MembershipDuration) VALUES('Monthly', 1)");
            Sql("INSERT INTO MembershipTypes(MembershipName, MembershipDuration) VALUES('Quarterly', 3)");
            Sql("INSERT INTO MembershipTypes(MembershipName, MembershipDuration) VALUES('Annually', 12)");
        }
        
        public override void Down()
        {
        }
    }
}
