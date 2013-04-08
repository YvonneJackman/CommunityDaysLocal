namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpFKs1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "UserProfile_UserId", "dbo.UserProfile");
            DropIndex("dbo.Company", new[] { "UserProfile_UserId" });
            DropColumn("dbo.Company", "UserProfile_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "UserProfile_UserId", c => c.Int());
            CreateIndex("dbo.Company", "UserProfile_UserId");
            AddForeignKey("dbo.Company", "UserProfile_UserId", "dbo.UserProfile", "UserId");
        }
    }
}
