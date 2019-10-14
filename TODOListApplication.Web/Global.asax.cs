using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TODOListApplication.Web.App_Start;

namespace TODOListApplication.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
         

            AreaRegistration.RegisterAllAreas();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoFacConfig.Configure();
        }
    }
}
