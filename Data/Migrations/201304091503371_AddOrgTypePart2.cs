namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrgTypePart2 : DbMigration
    {
        public override void Up()
        {          
            AddColumn("dbo.Company", "OrganisationTypeId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType", "OrganisationTypeId", cascadeDelete: true);
            CreateIndex("dbo.Company", "OrganisationTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Company", new[] { "OrganisationTypeId" });
            DropForeignKey("dbo.Company", "OrganisationTypeId", "dbo.OrganisationType");
            DropColumn("dbo.Company", "OrganisationTypeId");
        }
    }
}
