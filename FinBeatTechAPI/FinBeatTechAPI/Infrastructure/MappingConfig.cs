using AutoMapper;
using FinBeatTechAPI.BLL.DTO;
using FinBeatTechAPI.DAL.Entities;

namespace FinBeatTechAPI.Infrastructure
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateRequestDTO, Default>();
            CreateMap<Default, DefaultDTO>();
        }
    }
}
