namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EspritProducts", "LabAddress_StreetAddress", c => c.String());
            AddColumn("dbo.EspritProducts", "LabAddress_City", c => c.String());
            DropColumn("dbo.EspritProducts", "City");
            DropColumn("dbo.EspritProducts", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EspritProducts", "StreetAddress", c => c.String());
            AddColumn("dbo.EspritProducts", "City", c => c.String());
            DropColumn("dbo.EspritProducts", "LabAddress_City");
            DropColumn("dbo.EspritProducts", "LabAddress_StreetAddress");
        }
    }
}
