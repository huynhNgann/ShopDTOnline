using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;
using WebOnline.Libary;

namespace WebOnline.Controllers
{
    public class GioHangController : Controller
    {
        BHDBContext data = new BHDBContext();
        //lay gio hang
        public List<gioHang> Laygiohang()
        {
            List<gioHang> lstGiohang = Session["gioHang"] as List<gioHang>;
            if (lstGiohang == null)
            {
                //neu gio hang chưa ton tai thi khoi tao List
                lstGiohang = new List<gioHang>();
                Session["gioHang"] = lstGiohang;
            }
            return lstGiohang;
        }
        //them gio hang
        public ActionResult ThemGiohang(string iMaSp, string strURL)
        {
            //lay gio hang từ session
            List<gioHang> lstGiohang = Laygiohang();
            //kiem tra sp có tồn tại trong session chưa
            gioHang sanpham = lstGiohang.Find(n => n.iMaSp == iMaSp);
            if (sanpham == null)
            {
                sanpham = new gioHang(iMaSp);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);

            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<gioHang> lstGiohang = Session["gioHang"] as List<gioHang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //tong tien
        private double TongTien()
        {
            double iTongTien = 0;
            List<gioHang> lstGiohang = Session["gioHang"] as List<gioHang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongTien;
        }
        //xay dung trang gio hang
        public ActionResult GioHang()
        {
            List<gioHang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Shopp");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(string iMaSP)
        {
            //lay gio hang tư session
            List<gioHang> lstGiohang = Laygiohang();
            //kiem tra san pham da có trong Session chưa
            gioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMaSp == iMaSP);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMaSp == iMaSP);
                return RedirectToAction("GioHang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult Capnhatgiohang(string imaSP, FormCollection f)
        {
            //lay gio hang tu session
            List<gioHang> lstGiohang = Laygiohang();
            //kiem tra sp da có trong Session["gioHang"]
            gioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMaSp == imaSP);
            //neu ton tai thi cho sua sl
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGiohang()
        {
            //lay gio hang tu session
            List<gioHang> lstLaygiohang = Laygiohang();
            lstLaygiohang.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            //Kiem tra dang nhap
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Accounts");

            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Shopp");
            }
            //Lay gio hang tu Session
            List<gioHang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection collection)
        {
            //Them don hang
            donHang ddh = new donHang();
            khachHang kh = (khachHang)Session["Taikhoan"];
            List<gioHang> gh = Laygiohang();
            ddh.maKH = kh.maKH;
            ddh.ngayDat = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}",
            collection["Ngaygiao"]);
            ddh.ngayGH = DateTime.Parse(ngaygiao);
            ddh.trangThai = 0;
            ddh.daKichHoat = false;
            //  data.donHangs.InsertOnSubmit(ddh);
            //  data.SubmitChanges();
            //Them chi tiet don hang
            foreach (var item in gh)
            {
                ctDonHang ctdh = new ctDonHang();
                ctdh.soDH = ddh.soDH;
                ctdh.maSP = item.iMaSp;
                ctdh.soLuong = item.iSoLuong;
                ctdh.giaBan = (Double)item.dDongia;
             //  data.ctDonHangs.InsertOnSubmit(ctdh);

            }
               data.SubmitChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "Giohang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}