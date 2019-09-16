using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
            .Where(X => X.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                    .As<IEncrypter>()
                    .SingleInstance();
            
            builder.RegisterType<JwtHandler>()
                    .As<JwtHandler>()
                    .SingleInstance();
        }
    }
}