namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhomTk")]
    public partial class nhomTk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhomTk()
        {
            taiKhoanTVs = new HashSet<taiKhoanTV>();
        }

        [Key]
        public int maNhom { get; set; }

        [Required]
        [StringLength(35)]
        public string tenNhom { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taiKhoanTV> taiKhoanTVs { get; set; }
    }
}
