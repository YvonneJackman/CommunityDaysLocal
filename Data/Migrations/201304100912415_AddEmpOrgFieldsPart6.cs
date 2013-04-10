namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpOrgFieldsPart6 : DbMigration
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
            
            AddColumn("dbo.Company", "OrganisationType_OrganisationTypeId", c => c.Int());
            AddForeignKey("dbo.Company", "OrganisationType_OrganisationTypeId", "dbo.OrganisationType", "OrganisationTypeId");
            CreateIndex("dbo.Company", "OrganisationType_OrganisationTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "OrganisationType_OrganisationTypeId" });
            DropForeignKey("dbo.Company", "OrganisationType_OrganisationTypeId", "dbo.OrganisationType");
            DropColumn("dbo.Company", "OrganisationType_OrganisationTypeId");
            DropTable("dbo.OrganisationType");
        }
    }
}