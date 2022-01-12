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
    public class sanPhamsController : Controller
    {
        private BHDBContext db = new BHDBContext();

        // GET: Admin/sanPhams
        public ActionResult Index()
        {
            var sanPhams = db.sanPhams.Include(s => s.loaiSP).Include(s => s.taiKhoanTV);
            return View(sanPhams.ToList());
        }

        // GET: Admin/sanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/sanPhams/Create
        public ActionResult Create()
        {
            ViewBag.maLoai = new SelectList(db.loaiSPs, "maLoai", "loaiHang");
            ViewBag.taiKhoan = new SelectList(db.taiKhoanTVs, "taiKhoan", "matKhau");
            return View();
        }

        // POST: Admin/sanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,tenSP,hinhDD,ndTomTat,ngayDang,noiDung,taiKhoan,daDuyet,giaBan,giamGia,maLoai,nhaSanXuat,dvt")] sanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.sanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLoai = new SelectList(db.loaiSPs, "maLoai", "loaiHang", sanPham.maLoai);
            ViewBag.taiKhoan = new SelectList(db.taiKhoanTVs, "taiKhoan", "matKhau", sanPham.taiKhoan);
            return View(sanPham);
        }

        // GET: Admin/sanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLoai = new SelectList(db.loaiSPs, "maLoai", "loaiHang", sanPham.maLoai);
            ViewBag.taiKhoan = new SelectList(db.taiKhoanTVs, "taiKhoan", "matKhau", sanPham.taiKhoan);
            return View(sanPham);
        }

        // POST: Admin/sanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,tenSP,hinhDD,ndTomTat,ngayDang,noiDung,taiKhoan,daDuyet,giaBan,giamGia,maLoai,nhaSanXuat,dvt")] sanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLoai = new SelectList(db.loaiSPs, "maLoai", "loaiHang", sanPham.maLoai);
            ViewBag.taiKhoan = new SelectList(db.taiKhoanTVs, "taiKhoan", "matKhau", sanPham.taiKhoan);
            return View(sanPham);
        }

        // GET: Admin/sanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/sanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sanPham sanPham = db.sanPhams.Find(id);
            db.sanPhams.Remove(sanPham);
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
