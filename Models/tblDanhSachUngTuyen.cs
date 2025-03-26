using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblDanhSachUngTuyen
    {
        [Key]
        public int iMaDanhsach { get; set; }

        public string sMaTD { get; set; }

        public string sMaNV { get; set; }

        [ForeignKey("sMaNV")]
        public virtual tblNhanVien tblNhanVien { get; set; }

        [ForeignKey("sMaTD")]
        public virtual tblThongTinTuyenDung tblThongTinTuyenDung { get; set; }

        public tblHoSoNhanVien? tblHoSoNhanVien { get; set; } // Đảm bảo có navigation property

    }
}
