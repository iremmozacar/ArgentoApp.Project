using System;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
