using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcTemplate.Web.App_Start;
using MvcTemplate.Web.Models;
using MvcTemplate.Web.Services;
using MvcTemplate.Web.Services.Contacts;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

namespace MvcTemplate.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            
            ViewEngineConfig.RegisterViewEngines();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());

            //add services

            kernel.Bind<IGreetingService>().To<GreetingService>().InRequestScope();
            kernel.Bind<IPhonesServices>().To<PhonesServices>().InRequestScope();
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
        }



        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
    }
}
