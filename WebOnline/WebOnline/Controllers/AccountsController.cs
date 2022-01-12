using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;
using WebOnline.Libary;

namespace WebOnline.Controllers
{
    public class AccountsController : Controller
    {
        private BHDBContext db = new BHDBContext();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        /*      public ActionResult Details(string id)
              {
                  if (id == null)
                  {
                      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Account account = db.Accounts.Find(id);
                  if (account == null)
                  {
                      return HttpNotFound();
                  }
                  return View(account);
              }
              */
        // GET: Accounts/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }
        public ActionResult Login(Account auth)
        {
            Encryptor encty = new Encryptor();
            BHDBContext db = new BHDBContext();

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
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        public ActionResult Dangnhap(FormCollection collection)
        {
            //Gán giá trị người dùng nhập liệu cho các biến
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mạt khẩu";
            }
            else
            {
                //gán giá trị cho các đối tượng được tạo mới(kh)
                Account ac = db.Accounts.SingleOrDefault(n =>
                n.UserName == tendn && n.Password == matkhau);
                if (ac != null)

                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["TaiKhoan"] = ac;
                }
                else
                    ViewBag.Thongbao = "tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();

        }

    }
}


        // GET: Accounts/Edit/5
        /*    public ActionResult Edit(string id)
             {
                 if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }
                 Account account = db.Accounts.Find(id);
                 if (account == null)
                 {
                     return HttpNotFound();
                 }
                 return View(account);
             }

             // POST: Accounts/Edit/5
             // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
             // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
             [HttpPost]
             [ValidateAntiForgeryToken]
             public ActionResult Edit([Bind(Include = "UserName,Password")] Account account)
             {
                 if (ModelState.IsValid)
                 {
                     db.Entry(account).State = EntityState.Modified;
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }
                 return View(account);
             }

             // GET: Accounts/Delete/5
             public ActionResult Delete(string id)
             {
                 if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }
                 Account account = db.Accounts.Find(id);
                 if (account == null)
                 {
                     return HttpNotFound();
                 }
                 return View(account);
             }

             // POST: Accounts/Delete/5
             [HttpPost, ActionName("Delete")]
             [ValidateAntiForgeryToken]
             public ActionResult DeleteConfirmed(string id)
             {
                 Account account = db.Accounts.Find(id);
                 db.Accounts.Remove(account);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             protected override void Dispose(bool disposing)
             {
                 if (disposing)
                 {
                     db.Dispose();
                 }
                 base.Dispose(disposing);
             }
         }*/
    
