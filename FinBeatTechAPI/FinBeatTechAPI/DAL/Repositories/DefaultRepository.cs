using FinBeatTechAPI.DAL.Contexts;
using FinBeatTechAPI.DAL.Entities;
using FinBeatTechAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace FinBeatTechAPI.DAL.Repositories
{
    public class DefaultRepository : Repository<Default>, IDefaultRepository
    {
        DefaultContext _defaultDbContext;
        public DefaultRepository(DefaultContext defaultContext) : base(defaultContext) => _defaultDbContext = defaultContext;

        public async Task BulkInsertForDefaultAsync(IEnumerable<Default> entities)
        {          
            entities = entities.OrderBy(x => x.Code);

            using(var transaction = _defaultDbContext.Database.BeginTransaction())
            {
                try
                {
                    await _defaultDbContext.Database.ExecuteSqlAsync($"TRUNCATE TABLE [dbo].[DefaultTable]");

                    await _defaultDbContext.defaults.AddRangeAsync(entities);

                    await SaveAsync();

                    await transaction.CommitAsync();
                }
                catch
                {
                    transaction.Rollback();
                }
            }                  
        }
    }
}
