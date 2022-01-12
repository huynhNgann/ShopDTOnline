using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebOnline.Areas.Admin.Controllers
{
    public class DashController : Controller
    {
        // GET: Admin/Dash
        public ActionResult Index()
        {
            if (Session["useradmin"].Equals(""))
            {
                RedirectToAction("Login","Dash");
            }
            return View();
        }
        public ActionResult fortow()
        {
            return View();
        }
        public ActionResult blank()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

    }
}