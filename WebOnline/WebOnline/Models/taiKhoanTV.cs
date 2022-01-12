namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taiKhoanTV")]
    public partial class taiKhoanTV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taiKhoanTV()
        {
            baiViets = new HashSet<baiViet>();
            donHangs = new HashSet<donHang>();
            sanPhams = new HashSet<sanPham>();
        }

        [Key]
        [StringLength(20)]
        public string taiKhoan { get; set; }

        [StringLength(100)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string hoDem { get; set; }

        [Required]
        [StringLength(30)]
        public string tenTV { get; set; }

        public DateTime? ngaysinh { get; set; }

        public bool? gioiTinh { get; set; }

        [StringLength(20)]
        public string soDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(250)]
        public string diaChi { get; set; }

        public bool? trangThai { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        public int? maNhom { get; set; }

        public int? maQH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiViet> baiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donHang> donHangs { get; set; }

        public virtual nhomTk nhomTk { get; set; }

        public virtual quanHuyen quanHuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanPham> sanPhams { get; set; }
    }
}
