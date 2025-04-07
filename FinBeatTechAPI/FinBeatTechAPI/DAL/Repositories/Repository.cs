using EFCore.BulkExtensions;
using FinBeatTechAPI.DAL.Contexts;
using FinBeatTechAPI.DAL.Entities;
using FinBeatTechAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace FinBeatTechAPI.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DefaultContext _defaultDbContext;
        internal DbSet<T> dbSet;
        public Repository(DefaultContext defaultDbContext) 
        { 
            _defaultDbContext = defaultDbContext;
            dbSet = _defaultDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public async Task<(int, IEnumerable<T>)> GetAllWithPaginationAsync(int page, int limit, Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
                
            var totalRows = await query.CountAsync();

            return (totalRows, query.Skip(limit * (page - 1)).Take(limit));
        }

        public T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            Save();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            Save();
        }

        public void Save() => _defaultDbContext.SaveChanges();

        public async Task SaveAsync() => await _defaultDbContext.SaveChangesAsync();
    }
}
