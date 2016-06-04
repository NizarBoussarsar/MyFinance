namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "EspritProducts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EspritProducts", newName: "Products");
        }
    }
}
