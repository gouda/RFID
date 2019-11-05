using Autofac;
using Autofac.Integration.Mvc;
using RFID.SAL.Utilities;
using SWE.RFID.Manager;
using SWE.RFID.Manager.Interfaces;
using SWE.RFID.Manager.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SWE.RFID
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofacDependancies();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
        private void RegisterAutofacDependancies()
        {
            var builder = new ContainerBuilder();

            //Register all the types in the module...

            // register the global maindb's connection string
            //builder.RegisterInstance(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString)
            //    .Named<string>("connectionStringName");



            builder.RegisterType<WebServiceManager>()
     .As<IWebServiceManager>()
     .InstancePerRequest();
            builder.RegisterType<AccountManager>()
.As<IAccountManager>()
.InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<InventoryManager>()
.As<IInventoryManager>()
.InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            var resolver = new AutofacDependencyResolver(container);
            
            DependencyResolver.SetResolver(resolver);
        }


        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            
            string culture = System.Web.HttpContext.Current.Request.Cookies["lang"]?.Value ?? "en-US";
         

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }

    }
}
