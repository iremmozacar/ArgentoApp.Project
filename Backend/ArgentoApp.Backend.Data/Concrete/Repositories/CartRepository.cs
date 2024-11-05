using System;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
