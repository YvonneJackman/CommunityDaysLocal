namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpNotif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "SendNewProjectEmailFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "NewProjectDistance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "NewProjectDistance");
            DropColumn("dbo.Employee", "SendNewProjectEmailFlag");
        }
    }
}
