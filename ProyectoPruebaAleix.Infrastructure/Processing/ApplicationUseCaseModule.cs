using Autofac;
using ProyectoPruebaAleix.Infrastructure.Services;

namespace ProyectoPruebaAleix.Infrastructure.Processing
{
    public class ApplicationUseCaseModule : Module
    {
        public ApplicationUseCaseModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientService>().As<IClientService>().InstancePerLifetimeScope();
        }
    }
}
