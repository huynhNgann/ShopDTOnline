namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quanHuyen")]
    public partial class quanHuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public quanHuyen()
        {
            khachHangs = new HashSet<khachHang>();
            taiKhoanTVs = new HashSet<taiKhoanTV>();
        }

        [Key]
        public int maQH { get; set; }

        [Required]
        [StringLength(88)]
        public string tenQH { get; set; }

        [Required]
        [StringLength(65)]
        public string tinhThanh { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khachHang> khachHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taiKhoanTV> taiKhoanTVs { get; set; }
    }
}
