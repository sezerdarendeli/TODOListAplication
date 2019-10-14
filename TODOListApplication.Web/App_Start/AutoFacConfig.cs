using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TODOListApplication.Business.Services;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Registration;

namespace TODOListApplication.Web.App_Start
{
    public class AutoFacConfig
    {
        /// <summary>
        /// Process autofac configuration
        /// </summary>
        public static void Configure()
        {


            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            builder.RegisterType<UserService>().As<IUserService>();

            var container = IocRegistration.Boostrap(builder);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}