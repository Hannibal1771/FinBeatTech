using FinBeatTechAPI.DAL.Entities;
using System.Linq.Expressions;

namespace FinBeatTechAPI.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<(int, IEnumerable<T>)> GetAllWithPaginationAsync(int page, int limit, Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>>? filter = null, bool tracked = true); //для AsNoTracking, если есть нужда
        Task InsertAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(T entity);
        void Save();

        Task SaveAsync();
    }
}
