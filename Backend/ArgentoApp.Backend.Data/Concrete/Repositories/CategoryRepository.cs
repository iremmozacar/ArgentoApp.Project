using System;
using ArgentoApp.Backend.Entity.Concrete;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
