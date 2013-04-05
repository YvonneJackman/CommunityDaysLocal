// <auto-generated />
namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Opportunity", "OpportunityTitle", c => c.String(maxLength: 200));
            AlterColumn("dbo.Opportunity", "OpportunityDescription", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Opportunity", "OpportunityDescription", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Opportunity", "OpportunityTitle", c => c.String(maxLength: 50));
        }
    }
}