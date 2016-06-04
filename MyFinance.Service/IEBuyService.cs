using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Service
{
    public interface IEBuyService
    {
        void CreateProduct(Product p);
        Biological GetBiologicol(int id);
        IEnumerable<Category> GetCategories();
        Chemical GetChemical(int id);
        IEnumerable<Chemical> GetChemicals();
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(string categoryName);
    }

}
