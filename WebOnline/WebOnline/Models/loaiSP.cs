namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loaiSP")]
    public partial class loaiSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loaiSP()
        {
            baiViets = new HashSet<baiViet>();
            sanPhams = new HashSet<sanPham>();
        }

        [Key]
        public int maLoai { get; set; }

        [Required]
        [StringLength(88)]
        public string loaiHang { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<baiViet> baiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanPham> sanPhams { get; set; }
    }
}
