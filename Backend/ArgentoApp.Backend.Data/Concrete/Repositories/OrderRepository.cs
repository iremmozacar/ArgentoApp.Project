using System;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;


    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetSortedOrdersAsnyc(string? userId = null)
        {

            if (userId == null)
            {
                return await _dbContext
                    .Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.Product)
                    .ToListAsync();
            }
            return await _dbContext
                    .Orders
                    .OrderByDescending(x => x.OrderDate)
                    .Include(x => x.OrderItems)
                    .ThenInclude(y => y.Product)
                    .ToListAsync();
        }
    }

