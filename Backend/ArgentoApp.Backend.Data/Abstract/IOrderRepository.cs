using System;
using ArgentoApp.Backend.Data.Abstact;
using ArgentoApp.Backend.Entity.Concrete;

namespace ArgentoApp.Backend.Data.Abstract;

public interface IOrderRepository : IGenericRepository<Order>
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetSortedOrdersAsnyc(string? userId = null);
    }
}
