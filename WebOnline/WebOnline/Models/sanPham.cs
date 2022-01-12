namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanPham")]
    public partial class sanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanPham()
        {
            ctDonHangs = new HashSet<ctDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string maSP { get; set; }

        [Required]
        [StringLength(500)]
        public string tenSP { get; set; }

        public string hinhDD { get; set; }

        [StringLength(2000)]
        public string ndTomTat { get; set; }

        public DateTime? ngayDang { get; set; }

        [StringLength(4000)]
        public string noiDung { get; set; }

        [Required]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        public bool? daDuyet { get; set; }

        public int? giaBan { get; set; }

        public int? giamGia { get; set; }

        public int? maLoai { get; set; }

        [StringLength(89)]
        public string nhaSanXuat { get; set; }

        [StringLength(12)]
        public string dvt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctDonHang> ctDonHangs { get; set; }

        public virtual loaiSP loaiSP { get; set; }

        public virtual taiKhoanTV taiKhoanTV { get; set; }
    }
}
