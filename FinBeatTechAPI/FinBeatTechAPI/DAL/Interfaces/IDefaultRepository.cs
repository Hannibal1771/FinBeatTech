using FinBeatTechAPI.DAL.Entities;

namespace FinBeatTechAPI.DAL.Interfaces
{
    public interface IDefaultRepository : IRepository<Default>
    {
        public Task BulkInsertForDefaultAsync(IEnumerable<Default> entities);
    }
}
