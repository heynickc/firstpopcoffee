using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using FirstPopCoffee.RoastPlanning.Application;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using Ninject;
using WebUI.Infrastructure;
using WebUI.ReadModel;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeatureViewLocationRazorViewEngine());
        }
    }
}
