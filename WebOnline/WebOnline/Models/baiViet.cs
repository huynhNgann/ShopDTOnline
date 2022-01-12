namespace WebOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("baiViet")]
    public partial class baiViet
    {
        [Key]
        [StringLength(10)]
        public string maBV { get; set; }

        [Required]
        [StringLength(250)]
        public string tenBV { get; set; }

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

        public int? maLoai { get; set; }

        public virtual loaiSP loaiSP { get; set; }

        public virtual taiKhoanTV taiKhoanTV { get; set; }
    }
}
