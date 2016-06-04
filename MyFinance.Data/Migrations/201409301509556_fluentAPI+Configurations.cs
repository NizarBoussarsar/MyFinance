namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentAPIConfigurations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
            RenameTable(name: "dbo.ProviderProducts", newName: "Providings");
            RenameColumn(table: "dbo.Providings", name: "Provider_Id", newName: "Provider");
            RenameColumn(table: "dbo.Providings", name: "Product_ProductId", newName: "Product");
            RenameIndex(table: "dbo.Providings", name: "IX_Product_ProductId", newName: "IX_Product");
            RenameIndex(table: "dbo.Providings", name: "IX_Provider_Id", newName: "IX_Provider");
            DropPrimaryKey("dbo.Providings");
            AddColumn("dbo.EspritProducts", "IsBiological", c => c.Int());
            AlterColumn("dbo.MyCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EspritProducts", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.EspritProducts", "LabAddress_StreetAddress", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Providings", new[] { "Product", "Provider" });
            DropColumn("dbo.EspritProducts", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EspritProducts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Providings");
            AlterColumn("dbo.EspritProducts", "LabAddress_StreetAddress", c => c.String());
            AlterColumn("dbo.EspritProducts", "Description", c => c.String());
            AlterColumn("dbo.MyCategories", "Name", c => c.String());
            DropColumn("dbo.EspritProducts", "IsBiological");
            AddPrimaryKey("dbo.Providings", new[] { "Provider_Id", "Product_ProductId" });
            RenameIndex(table: "dbo.Providings", name: "IX_Provider", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.Providings", name: "IX_Product", newName: "IX_Product_ProductId");
            RenameColumn(table: "dbo.Providings", name: "Product", newName: "Product_ProductId");
            RenameColumn(table: "dbo.Providings", name: "Provider", newName: "Provider_Id");
            RenameTable(name: "dbo.Providings", newName: "ProviderProducts");
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
        }
    }
}
