namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpFKs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "DirectorateId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "DepartmentId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Employee", "CountryId", "dbo.Country", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "LocationId", "dbo.Location", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "DirectorateId", "dbo.Directorate", "DirectorateId", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            CreateIndex("dbo.Employee", "CountryId");
            CreateIndex("dbo.Employee", "LocationId");
            CreateIndex("dbo.Employee", "DirectorateId");
            CreateIndex("dbo.Employee", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "DirectorateId" });
            DropIndex("dbo.Employee", new[] { "LocationId" });
            DropIndex("dbo.Employee", new[] { "CountryId" });
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "DirectorateId", "dbo.Directorate");
            DropForeignKey("dbo.Employee", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Employee", "CountryId", "dbo.Country");
            DropColumn("dbo.Employee", "DepartmentId");
            DropColumn("dbo.Employee", "DirectorateId");
            DropColumn("dbo.Employee", "LocationId");
            DropColumn("dbo.Employee", "CountryId");
        }
    }
}
