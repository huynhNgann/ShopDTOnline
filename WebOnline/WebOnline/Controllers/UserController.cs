using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;
using WebOnline.Libary;

namespace WebOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        // GET: Admin/Auth
        Encryptor encty = new Encryptor();
        BHDBContext db = new BHDBContext();
        // GET: Admin/Auth
        public ActionResult Login(Account auth)
        {


            ViewBag.Message = "";
            if (ModelState.IsValid)
            {

                auth.Password = encty.MD5Hash(auth.Password);//mật khẩu mã hóa
                if (!db.Accounts.Where(m => m.UserName == auth.UserName).Count().Equals(0))
                {
                    if (!db.Accounts.Where(m => m.UserName == auth.UserName && m.Password == auth.Password).Count().Equals(0))
                    {
                        var user_login = db.Accounts.Where(m => m.UserName == auth.UserName && m.Password == auth.Password).First();
                        Session["useradmin"] = user_login.UserName;
                        
                        return RedirectToAction("Index", "Shopp");
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
