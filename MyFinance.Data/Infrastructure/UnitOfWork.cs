using MyFinance.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyFinanceContext dataContext;
        DatabaseFactory dbFactory;
        public UnitOfWork(DatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        private IProviderRepository providerRepository;
        IProviderRepository IUnitOfWork.ProviderRepository
        {
            get { return providerRepository ?? (providerRepository = new ProviderRepository(dbFactory)); }
        }
        private ICategoryRepository categoryRepository;
        ICategoryRepository IUnitOfWork.CategoryRepository
        {
            get { return categoryRepository ?? (categoryRepository = new CategoryRepository(dbFactory)); }
        }
        private IProductRepository productRepository;
        IProductRepository IUnitOfWork.ProductRepository
        {
            get { return productRepository ?? (productRepository = new ProductRepository(dbFactory)); }
        }
        protected MyFinanceContext DataContext
        {
            get
            {
                return dataContext ?? (dataContext = dbFactory.Get());
            }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }

}
