namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpOrgFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunity", "RiskAssessmentDocLink", c => c.Int(nullable: false));
            AddColumn("dbo.Opportunity", "SEARSNumber", c => c.String());
            AddColumn("dbo.Opportunity", "RecurringEventFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Opportunity", "OptOutOfReminderEmails", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "EmployeePayrollNumber", c => c.String());
            AddColumn("dbo.Employee", "CostCentre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "CostCentre");
            DropColumn("dbo.Employee", "EmployeePayrollNumber");
            DropColumn("dbo.Opportunity", "OptOutOfReminderEmails");
            DropColumn("dbo.Opportunity", "RecurringEventFlag");
            DropColumn("dbo.Opportunity", "SEARSNumber");
            DropColumn("dbo.Opportunity", "RiskAssessmentDocLink");
        }
    }
}
