using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using ArgentoApp.Backend.Data.Abstact;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace ArgentoApp.Backend.Data.Concrete.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

    protected readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;


    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (predicate != null)
        {
            query = predicate(query);
        }
        if (options != null)
        {
            query = query.Where(options);

        }
        return await query.ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (predicate != null)
        {
            query = predicate(query);
        }
        if (options != null)
        {
            query = query.Where(options);

        }
        return await query.AsNoTracking().SingleOrDefaultAsync();
    }

    public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (predicate != null)
        {
            query = predicate(query);
        }
        if (options != null)
        {
            query = query.Where(options);

        }
        return await query.CountAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}

