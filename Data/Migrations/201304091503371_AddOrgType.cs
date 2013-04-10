namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrgType : DbMigration
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
        }
        
        public override void Down()
        {
            DropTable("dbo.OrganisationType");
        }
    }
}
