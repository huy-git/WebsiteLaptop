using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WEBLAPTOP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["songuoitruycap"] = 0;
        }
        protected void Session_Start()
        {
            Application["songuoitruycap"] = int.Parse(Application["songuoitruycap"].ToString()) + 1;
            Session["giohang"] = null;
        }
        protected void Session_End()
        {
            Application["songuoitruycap"] = int.Parse(Application["songuoitruycap"].ToString() ) - 1;
            Session["giohang"] = null;
        }
    }
}
