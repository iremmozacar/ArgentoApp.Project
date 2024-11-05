using System;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
