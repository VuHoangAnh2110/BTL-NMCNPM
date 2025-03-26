using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblDanhSachUngTuyen
    {
        [Key]
        public int iMaDanhsach { get; set; }

        [Required]
        public string sMaTD { get; set; } = null!;

        [Required]
        public string sMaNV { get; set; } = null!;

        // Thiết lập quan hệ với tblNhanVien
        [ForeignKey("sMaNV")]
        public virtual tblNhanVien tblNhanVien { get; set; } = null!;

        // Thiết lập quan hệ với tblThongTinTuyenDung
        [ForeignKey("sMaTD")]
        public virtual tblThongTinTuyenDung tblThongTinTuyenDung { get; set; } = null!;

        // Không cần tham chiếu trực tiếp tới tblHoSoNhanVien
    }
}
