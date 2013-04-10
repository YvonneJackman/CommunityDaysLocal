namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpOrgFieldsPart3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType");
            DropIndex("dbo.Company", new[] { "OrganisationTypeId" });
            DropColumn("dbo.Company", "OrganisationTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "OrganisationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Company", "OrganisationTypeId");
            AddForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType", "OrganisationTypeId", cascadeDelete: true);
        }
    }
}