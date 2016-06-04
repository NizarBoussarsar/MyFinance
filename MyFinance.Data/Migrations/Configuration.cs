namespace MyFinance.Data.Migrations
{
    using MyFinance.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyFinance.Data.MyFinanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyFinance.Data.MyFinanceContext";
        }

        protected override void Seed(MyFinance.Data.MyFinanceContext context)
        {
            context.Categories.AddOrUpdate(
              p => p.Name,  //Uniqueness property
              new Category { Name = "Medicament" },
              new Category { Name = "Vetement" },
              new Category { Name = "Meuble" }
            );
            context.SaveChanges();

        }
    }
}
