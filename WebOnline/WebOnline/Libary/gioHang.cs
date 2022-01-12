using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebOnline.Models;
namespace WebOnline.Libary
{
    public class gioHang
    {
        BHDBContext data = new BHDBContext();
        public string iMaSp { set; get; }
        public string sTenSP { set; get; }
        public string sAnhBia { set; get; }
        public Double dDongia { set; get; }
        public int iSoLuong { set; get; }
        public Double dThanhtien
        {
            get { return iSoLuong * dDongia; }
        }
        //khởi tạo giỏ hàng Masach được truyền vào với số lượng mặc định là 1
        public gioHang(string maSP)
        {
            iMaSp = maSP;
            sanPham sp = data.sanPhams.Single(n => n.maSP == iMaSp);
            sTenSP = sp.tenSP;
            sAnhBia = sp.hinhDD;
            dDongia = double.Parse(sp.giaBan.ToString());
            iSoLuong = 1;
        }

    }
}