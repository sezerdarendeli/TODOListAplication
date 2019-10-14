using Autofac;
using TODOListApplication.Business.Services;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Core;
using TODOListApplication.Data;

namespace TODOListApplication.Registration
{
    public class IocRegistration
    {
        public static IContainer Boostrap(ContainerBuilder containerBuilder = null)
        {
            containerBuilder = containerBuilder ?? new ContainerBuilder();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<TODOListApplicationRepository>().As<ITodoListApplicationRepository>();
            containerBuilder.RegisterType<ToDoService>().As<IToDoService>();


            return IocContainer.Boostrap(containerBuilder);
        }
    }
}
