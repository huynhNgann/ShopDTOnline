namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("donHang")]
    public partial class donHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donHang()
        {
            ctDonHangs = new HashSet<ctDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string soDH { get; set; }

        [Required]
        [StringLength(10)]
        public string maKH { get; set; }

        [Required]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        public DateTime? ngayDat { get; set; }

        public bool? daKichHoat { get; set; }

        public DateTime? ngayGH { get; set; }

        [StringLength(250)]
        public string diaChiGH { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctDonHang> ctDonHangs { get; set; }

        public virtual khachHang khachHang { get; set; }

        public virtual taiKhoanTV taiKhoanTV { get; set; }
    }
}
