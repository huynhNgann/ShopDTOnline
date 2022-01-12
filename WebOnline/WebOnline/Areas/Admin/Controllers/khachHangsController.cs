using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;

namespace WebOnline.Areas.Admin.Controllers
{
    public class khachHangsController : Controller
    {
        private BHDBContext db = new BHDBContext();

        // GET: Admin/khachHangs
        public ActionResult Index()
        {
            var khachHangs = db.khachHangs.Include(k => k.quanHuyen);
            return View(khachHangs.ToList());
        }

        // GET: Admin/khachHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachHang khachHang = db.khachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/khachHangs/Create
        public ActionResult Create()
        {
            ViewBag.maQH = new SelectList(db.quanHuyens, "maQH", "tenQH");
            return View();
        }

        // POST: Admin/khachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKH,tenKH,soDT,email,diaChi,ngaySinh,gioiTinh,ghiChu,maQH,diemTichLuy")] khachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.khachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maQH = new SelectList(db.quanHuyens, "maQH", "tenQH", khachHang.maQH);
            return View(khachHang);
        }

        // GET: Admin/khachHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachHang khachHang = db.khachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maQH = new SelectList(db.quanHuyens, "maQH", "tenQH", khachHang.maQH);
            return View(khachHang);
        }

        // POST: Admin/khachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKH,tenKH,soDT,email,diaChi,ngaySinh,gioiTinh,ghiChu,maQH,diemTichLuy")] khachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maQH = new SelectList(db.quanHuyens, "maQH", "tenQH", khachHang.maQH);
            return View(khachHang);
        }

        // GET: Admin/khachHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachHang khachHang = db.khachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/khachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            khachHang khachHang = db.khachHangs.Find(id);
            db.khachHangs.Remove(khachHang);
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
    }
}
