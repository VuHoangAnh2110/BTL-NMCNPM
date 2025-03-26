using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblHoSoNhanVien
    {
        [Key]
        public int iMaHoSoNV { get; set; } // Vẫn là khóa chính

        [Required]
        public string sMaNV { get; set; } = null!;

        public string? sTenNV { get; set; }
        public string? sEmail { get; set; }
        public int? iCCCD { get; set; }
        public DateTime? dNgaysinh { get; set; }
        public int? iSDT { get; set; }
        public string? sDiachi { get; set; }
        public string? sHocvan { get; set; }
        public string? sKinhnghiem { get; set; }

        // Quan hệ 1-1 với tblNhanVien
        [ForeignKey("sMaNV")]
        public virtual tblNhanVien tblNhanVien { get; set; } = null!;

        // Quan hệ 1-N với tblDanhSachUngTuyen, khóa ngoại phải trỏ đến `sMaNV`
        public virtual ICollection<tblDanhSachUngTuyen>? tblDanhSachUngTuyen { get; set; }
    }
}
