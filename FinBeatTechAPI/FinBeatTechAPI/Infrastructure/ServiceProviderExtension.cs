using FinBeatTechAPI.BLL.Interfaces;
using FinBeatTechAPI.BLL.Service;
using FinBeatTechAPI.DAL.Interfaces;
using FinBeatTechAPI.DAL.Repositories;

namespace FinBeatTechAPI.Infrastructure
{
    public static class ServiceProviderExtension
    {
        public static void AddDefaultRepository(this IServiceCollection services)
            => services.AddScoped<IDefaultRepository, DefaultRepository>();

        public static void AddDefaultService (this IServiceCollection services)
            => services.AddScoped<IDefaultService, DefaultService>();
    }
}
