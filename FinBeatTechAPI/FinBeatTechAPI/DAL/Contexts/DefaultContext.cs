using FinBeatTechAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinBeatTechAPI.DAL.Contexts
{
    public class DefaultContext : DbContext 
    {
        private readonly IConfiguration _configuration;

        public DefaultContext(IConfiguration configuration) => _configuration = configuration;

        public DbSet<Default> defaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
    }
}
