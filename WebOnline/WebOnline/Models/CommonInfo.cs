using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebOnline.Models;

namespace WebOnline.Models
{
    public class CommonInfo
    {
        private BHDBContext data;
        public CommonInfo()
        {
            data = new BHDBContext();
        }
        public IEnumerable<WebOnline.Models.loaiSP> nhomHang()
        {
            return data.loaiSPs;
        }
        public IEnumerable<WebOnline.Models.sanPham> sanPhamdungchung()
        {
            return data.sanPhams;
        }
        public IEnumerable<WebOnline.Models.sanPham> sanphamMoi(int n)
        {
            return data.sanPhams.OrderByDescending(a => a.ngayDang).Take(n);
        }
        public IEnumerable<WebOnline.Models.baiViet> baiVietDungChung()
        {
            return data.baiViets;
        }
        public IEnumerable<loaiSP> Nhomhang()
        {
            
                /*Hiện thị kết quả sản phẩm tìm kiếm*/
                return this.data.loaiSPs;
            }
        }
       

    }
