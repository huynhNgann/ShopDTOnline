using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Libary;
using WebOnline.Models;
namespace WebOnline.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        Encryptor encty = new Encryptor();
        BHDBContext db = new BHDBContext();
        // GET: Admin/Auth
        public ActionResult Login(User auth)
        {

        
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {

                auth.PassAdmin = encty.MD5Hash(auth.PassAdmin);//mật khẩu mã hóa
                if (!db.Users.Where(m => m.UserName == auth.UserName).Count().Equals(0))
                {
                    if (!db.Users.Where(m => m.UserName == auth.UserName && m.PassAdmin == auth.PassAdmin).Count().Equals(0))
                    {
                        var user_login = db.Users.Where(m => m.UserName == auth.UserName && m.PassAdmin == auth.PassAdmin).First();
                        Session["useradmin"] = user_login.UserName;
                        Session["useradmin"] = user_login.Name;
                        return RedirectToAction("Index", "Dash");
                    }

                    else
                    {
                        ViewBag.Message = "Tên đăng nhập hoặc mật khẩu bị sai";
                    }
                }


                else
                {
                    ViewBag.Message = "Thông tin không chính xác";
                }
            }

                return View();
            }

        }
    }

