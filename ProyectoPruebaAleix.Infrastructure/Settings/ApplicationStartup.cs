using Autofac;
using Microsoft.Extensions.Configuration;
using ProyectoPruebaAleix.Infrastructure.Processing;

namespace ProyectoPruebaAleix.Infrastructure.Settings
{
    public class ApplicationStartup
    {
        public static void Initialize(ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new ApplicationUseCaseModule());
            builder.RegisterModule(new SqlServerModule(configuration));
            builder.RegisterModule(new DataAccessModule());
        }

    }
}
