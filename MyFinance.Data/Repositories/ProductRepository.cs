using MyFinance.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IProductRepository : IRepository<Product> { }

}
