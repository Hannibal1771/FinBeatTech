using FinBeatTechAPI.BLL.DTO;
using FinBeatTechAPI.DAL.Entities;
using System.Linq.Expressions;

namespace FinBeatTechAPI.BLL.Interfaces
{
    public interface IDefaultService
    {
        public Task<(int, IEnumerable<DefaultDTO>)> GetDefaultDataAsync(GetRequestDTO requestDTO, Expression<Func<Default, bool>>? filter = null);

        public Task CreateDefaultDataAsync(IEnumerable<CreateRequestDTO> requestDTOsList);
    }
}
