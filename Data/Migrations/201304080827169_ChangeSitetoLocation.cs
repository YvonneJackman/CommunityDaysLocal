namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSitetoLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Site", "CountryId", "dbo.Country");
            DropIndex("dbo.Site", new[] { "CountryId" });
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(maxLength: 50),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            DropTable("dbo.Site");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(maxLength: 50),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            DropIndex("dbo.Location", new[] { "CountryId" });
            DropForeignKey("dbo.Location", "CountryId", "dbo.Country");
            DropTable("dbo.Location");
            CreateIndex("dbo.Site", "CountryId");
            AddForeignKey("dbo.Site", "CountryId", "dbo.Country", "CountryId", cascadeDelete: true);
        }
    }
}