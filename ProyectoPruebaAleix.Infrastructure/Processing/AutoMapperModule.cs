using Autofac;
using AutoMapper;
using ProyectoPruebaAleix.Infrastructure.Settings;

namespace ProyectoPruebaAleix.Infrastructure.Processing
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            }
            )).AsSelf()
            .SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
