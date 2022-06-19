using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoPruebaAleix.Domain;
using ProyectoPruebaAleix.Infrastructure.Configuration;

namespace ProyectoPruebaAleix.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public virtual DbSet<Client> Clients { get; set; }
    }
}
