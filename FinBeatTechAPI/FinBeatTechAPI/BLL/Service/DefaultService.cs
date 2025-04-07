using AutoMapper;
using FinBeatTechAPI.BLL.DTO;
using FinBeatTechAPI.BLL.Interfaces;
using FinBeatTechAPI.DAL.Entities;
using FinBeatTechAPI.DAL.Interfaces;
using FinBeatTechAPI.DAL.Repositories;
using System.Linq.Expressions;

namespace FinBeatTechAPI.BLL.Service
{
    public class DefaultService : IDefaultService
    {
        IDefaultRepository _defaultRepository;
        private readonly IMapper _mapper;
        public DefaultService(IDefaultRepository defaultRepository,IMapper mapper)
        {
            _defaultRepository = defaultRepository;
            _mapper = mapper;
        }

        public async Task CreateDefaultDataAsync(IEnumerable<CreateRequestDTO> requestDTOsList) => await _defaultRepository.BulkInsertForDefaultAsync(_mapper.Map<IEnumerable<Default>>(requestDTOsList));

        public async Task<(int, IEnumerable<DefaultDTO>)> GetDefaultDataAsync(GetRequestDTO requestDTO, Expression<Func<Default, bool>>? filter = null)
        {
            IEnumerable<Default> dataList = null;
            int totalRows = 0;

           (totalRows, dataList) = await _defaultRepository.GetAllWithPaginationAsync(requestDTO.Page, requestDTO.Limit, filter);
          
            return (totalRows, _mapper.Map<IEnumerable<DefaultDTO>>(dataList));
        }
    }
}
