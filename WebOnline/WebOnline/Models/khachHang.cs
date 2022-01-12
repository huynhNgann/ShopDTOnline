namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachHang")]
    public partial class khachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachHang()
        {
            donHangs = new HashSet<donHang>();
        }

        [Key]
        [StringLength(10)]
        public string maKH { get; set; }

        [Required]
        [StringLength(50)]
        public string tenKH { get; set; }

        [StringLength(20)]
        public string soDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(250)]
        public string diaChi { get; set; }

        public DateTime? ngaySinh { get; set; }

        public bool? gioiTinh { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        public int? maQH { get; set; }

        public int? diemTichLuy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donHang> donHangs { get; set; }

        public virtual quanHuyen quanHuyen { get; set; }
    }
}
