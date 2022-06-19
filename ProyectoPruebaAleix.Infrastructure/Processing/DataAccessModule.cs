using Autofac;
using ProyectoPruebaAleix.Infrastructure.Repositories;

namespace ProyectoPruebaAleix.Infrastructure.Processing
{
    public class DataAccessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerLifetimeScope();
        }

    }
}
