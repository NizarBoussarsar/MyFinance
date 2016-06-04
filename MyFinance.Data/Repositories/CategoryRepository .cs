using MyFinance.Data.Infrastructure;
using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }

    public interface ICategoryRepository : IRepository<Category> { }

}
