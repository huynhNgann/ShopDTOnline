using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;
namespace WebOnline.Controllers
{
    public class ShoppController : Controller
    {
        BHDBContext data = new BHDBContext();
        // GET: Shop

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: Shop/Create
        public ActionResult Single(String id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SPTheoNSX()
        {
            var chude = from d in data.sanPhams select d;
            return PartialView(chude);
        }

        public ActionResult ShortCodes()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
