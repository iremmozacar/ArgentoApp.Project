using System;
using ArgentoApp.Backend.Entity.Concrete.Abstact;

namespace ArgentoApp.Backend.Data.Abstact;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
}
