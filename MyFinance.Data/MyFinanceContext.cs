using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Domain.Entities;
using System.Data.Entity;
using MyFinance.Data.Configurations;

namespace MyFinance.Data
{


    public class MyFinanceContext : DbContext
    {
        public MyFinanceContext()
            : base("Name=DefaultConnection")
        {
            Database.SetInitializer<MyFinanceContext>(new MyFinanceContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class MyFinanceContextInitializer : DropCreateDatabaseIfModelChanges<MyFinanceContext>
    {
        protected override void Seed(MyFinanceContext context)
        {
            var listCategories = new List<Category>{
            	new Category{Name="Medicament" },
            	new Category{Name="Vetement" },
            	new Category{Name="Meuble" },                   	
        	};

            context.Categories.AddRange(listCategories);
            context.SaveChanges();
        }

    }



}
