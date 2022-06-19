using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProyectoPruebaAleix.Infrastructure.Processing
{
    public class SqlServerModule : Module
    {
        private IConfiguration _configuration;
        public SqlServerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<ApplicationDbContext>();
                opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                return new ApplicationDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
