using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Registration;


namespace TODOListApplication.Core
{
    public class IocContainer
    {
        private static IContainer container;

        public static T Resolve<T>()
        {
            if (!typeof(T).IsInterface)
            {
                throw new Exception($"{typeof(T).Name} is not interface.");
 
            }

            try
            {
                return container.Resolve<T>();
            }
            catch (ComponentNotRegisteredException notFoundException)
            {
                throw new Exception($"{typeof(T).Name} is not registered.{notFoundException.Message}");
            }
            catch (Exception)
            {
                throw new Exception($"{typeof(T).Name} could not be resolved.");
            }
        }

        public static IContainer Boostrap(ContainerBuilder containerBuilder)
        {
            return container = containerBuilder.Build();
        }

    }
}
