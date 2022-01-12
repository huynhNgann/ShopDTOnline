namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ctDonHang")]
    public partial class ctDonHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string soDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string maSP { get; set; }

        public int? soLuong { get; set; }

        public double? giaBan { get; set; }

        public long? giamGia { get; set; }

        public virtual sanPham sanPham { get; set; }

        public virtual donHang donHang { get; set; }
    }
}
