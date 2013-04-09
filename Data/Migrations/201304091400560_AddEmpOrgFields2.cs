namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpOrgFields2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "OptOutOfReminderEmails", c => c.Boolean(nullable: false));
            DropColumn("dbo.Opportunity", "OptOutOfReminderEmails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Opportunity", "OptOutOfReminderEmails", c => c.Boolean(nullable: false));
            DropColumn("dbo.Company", "OptOutOfReminderEmails");
        }
    }
}