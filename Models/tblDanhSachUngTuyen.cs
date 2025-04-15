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

        [ForeignKey(nameof(sMaNV))]
        public virtual tblNhanVien? NhanVien { get; set; }

        [ForeignKey(nameof(sMaTD))]
        public virtual tblThongTinTuyenDung? ThongTinTuyenDung { get; set; }


        // Không cần tham chiếu trực tiếp tới tblHoSoNhanVien
    }
}
