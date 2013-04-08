namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Site", "CountryId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Site", "CountryId", "dbo.Country", "CountryId", cascadeDelete: true);
            CreateIndex("dbo.Site", "CountryId");
            DropColumn("dbo.Site", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Site", "Test", c => c.String(maxLength: 50));
            DropIndex("dbo.Site", new[] { "CountryId" });
            DropForeignKey("dbo.Site", "CountryId", "dbo.Country");
            DropColumn("dbo.Site", "CountryId");
        }
    }
}
