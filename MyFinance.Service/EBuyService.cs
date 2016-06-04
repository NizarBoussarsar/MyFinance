using MyFinance.Data.Infrastructure;
using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Service
{
    public class EBuyService : IEBuyService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Category> GetCategories()
        {
            var categories = utOfWork.CategoryRepository.GetAll();
            return categories;
        }
        IEnumerable<Biological> GetBiologicols()
        {
            var Biologicals = utOfWork.ProductRepository.GetAll().OfType<Biological>();
            return Biologicals;
        }
        public IEnumerable<Product> GetProducts()
        {
            var Products = utOfWork.ProductRepository.GetAll();
            return Products;
        }
        public IEnumerable<Chemical> GetChemicals()
        {
            var Chemicals = utOfWork.ProductRepository.GetAll().OfType<Chemical>();
            return Chemicals;
        }
        public Biological GetBiologicol(int id)
        {
            var Biological = utOfWork.ProductRepository.GetById(id) as Biological;
            return Biological;
        }
        public Chemical GetChemical(int id)
        {
            var Chemical = utOfWork.ProductRepository.GetById(id) as Chemical;
            return Chemical;
        }

        public void CreateProduct(Product p)
        {
            utOfWork.ProductRepository.Add(p);
            utOfWork.Commit();
        }
        public Product GetProduct(int id)
        {
            var Product = utOfWork.ProductRepository.GetById(id);
            return Product;
        }
        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            var Products = utOfWork.ProductRepository.GetMany(x => x.Category.Name == categoryName);
            //var category = utOfWork.CategoryRepository.Get(x => x.Name == categoryName);
            //var Products = utOfWork.ProductRepository.GetMany(x => x.CategoryId == category.CategoryId);
            return Products;
        }
    }

}
