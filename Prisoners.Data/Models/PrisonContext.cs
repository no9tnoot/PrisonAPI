using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Prisoners.Data.Models
{
    public class PrisonContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public PrisonContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("default");
        }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
