namespace MyFinance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Providers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Providers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Providers", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Providers", "Email", c => c.String());
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
