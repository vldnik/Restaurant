using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        
        public Repository(RestaurantDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
 
        public IQueryable<TEntity> FindAll()
        {
            return _dbSet.AsNoTracking();
        }
 
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }
 
        public void Create(TEntity entity)
        { 
            _dbSet.Add(entity);
        }
 
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
 
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}