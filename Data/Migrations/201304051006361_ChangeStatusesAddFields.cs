namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatusesAddFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "CompanyApprovedFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Opportunity", "RiskAssessmentCompleteFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Opportunity", "ContactMadeFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Opportunity", "Notes", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Company", "CompanyApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "CompanyApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Opportunity", "Notes");
            DropColumn("dbo.Opportunity", "ContactMadeFlag");
            DropColumn("dbo.Opportunity", "RiskAssessmentCompleteFlag");
            DropColumn("dbo.Company", "CompanyApprovedFlag");
        }
    }
}
