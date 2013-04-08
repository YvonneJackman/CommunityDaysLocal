namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ManagerEmail", c => c.String());
            AddColumn("dbo.Employee", "ManagerFirstName", c => c.String());
            AddColumn("dbo.Employee", "ManagerLastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "ManagerLastName");
            DropColumn("dbo.Employee", "ManagerFirstName");
            DropColumn("dbo.Employee", "ManagerEmail");
        }
    }
}
