using System;
using ArgentoApp.Backend.Data.Abstact;
using ArgentoApp.Backend.Entity.Concrete.Abstact;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }
}
