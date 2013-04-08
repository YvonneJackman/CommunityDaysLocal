namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeFirstName", c => c.String());
            AddColumn("dbo.Employee", "EmployeeLastName", c => c.String());
            AddColumn("dbo.Location", "Postcode", c => c.String(maxLength: 8));
            DropColumn("dbo.Employee", "EmployeeName");
            DropColumn("dbo.Employee", "EmployeeDepartment");
            DropColumn("dbo.Employee", "EmployeeWorkPostcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "EmployeeWorkPostcode", c => c.String());
            AddColumn("dbo.Employee", "EmployeeDepartment", c => c.String());
            AddColumn("dbo.Employee", "EmployeeName", c => c.String());
            DropColumn("dbo.Location", "Postcode");
            DropColumn("dbo.Employee", "EmployeeLastName");
            DropColumn("dbo.Employee", "EmployeeFirstName");
        }
    }
}
