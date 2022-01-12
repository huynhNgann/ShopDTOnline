using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebOnline.Models;
namespace WebOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["dungchung"] = new CommonInfo();
        }
        protected void Session_Start()
        {
            Session["useradmin"] = "";
            Session["userlogin"] = "";
            Session["gioHang"] = "";
           

        }






    }
}
