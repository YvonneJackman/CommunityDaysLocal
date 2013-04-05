namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Company", new[] { "UserId" });
            RenameColumn(table: "dbo.Company", name: "UserId", newName: "UserProfile_UserId");
            CreateTable(
                "dbo.CompanyUserProfileMap",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CompanyUserProfileMapId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyUserProfileMapId)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
            AddForeignKey("dbo.Company", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Company", "UserProfile_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompanyUserProfileMap", new[] { "UserId" });
            DropIndex("dbo.CompanyUserProfileMap", new[] { "CompanyId" });
            DropIndex("dbo.Company", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.CompanyUserProfileMap", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.CompanyUserProfileMap", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Company", "UserProfile_UserId", "dbo.UserProfile");
            DropTable("dbo.CompanyUserProfileMap");
            RenameColumn(table: "dbo.Company", name: "UserProfile_UserId", newName: "UserId");
            CreateIndex("dbo.Company", "UserId");
            AddForeignKey("dbo.Company", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
        }
    }
}
