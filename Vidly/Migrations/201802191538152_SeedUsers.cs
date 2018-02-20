namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'41fd078b-9fd4-4309-88be-9228a2a20d86', N'guest@vidly.com', 0, N'AKJiq0JkAwqKciiVk0ZvlV0uk3irSDbAGaduEJpPsq0u7mCd+/So26o74tw4X/E6Eg==', N'1347afef-b6c5-4281-a126-9a6ced2e3ab0', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'702a036c-95df-4c6e-b3db-97441c804c99', N'admin@vidly.com', 0, N'ANqav6UUbrB8S7YCOfbMdgAXz2iDVQczIKxe9X/WECqzebDnCk0gZNhuvdwaAEeSAg==', N'fe7cb197-451d-48c3-8dde-41d04db46c8f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b5409d09-8ec6-4f94-818f-38a2a20055e6', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'702a036c-95df-4c6e-b3db-97441c804c99', N'b5409d09-8ec6-4f94-818f-38a2a20055e6')
        ");
        }
        
        public override void Down()
        {
        }
    }
}
