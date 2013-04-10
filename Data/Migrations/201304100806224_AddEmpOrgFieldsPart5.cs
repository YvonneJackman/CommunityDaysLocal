namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpOrgFieldsPart5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganisationType",
                c => new
                    {
                        OrganisationTypeId = c.Int(nullable: false, identity: true),
                        OrganisationTypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OrganisationTypeId);
            
            AddColumn("dbo.Company", "OrganisationTypeId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType", "OrganisationTypeId", cascadeDelete: true);
            CreateIndex("dbo.Company", "OrganisationTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "OrganisationTypeId" });
            DropForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType");
            DropColumn("dbo.Company", "OrganisationTypeId");
            DropTable("dbo.OrganisationType");
        }
    }
}
