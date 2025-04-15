using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblNhanVien
    {
        [Key]
        public string sMaNV { get; set; } = null!;

        public string? sMaTK { get; set; }

        // Thiết lập quan hệ với tblTaiKhoan
        [ForeignKey("sMaTK")]
        public virtual tblTaiKhoan? tblTaiKhoan { get; set; }

        // Một nhân viên có thể có nhiều hồ sơ nhân viên
        public virtual ICollection<tblHoSoNhanVien>? tblHoSoNhanVien { get; set; }

        // Một nhân viên có thể ứng tuyển nhiều lần
        [InverseProperty("NhanVien")]
        public virtual ICollection<tblDanhSachUngTuyen> DanhSachUngTuyen { get; set; } = new List<tblDanhSachUngTuyen>();
        
    }
}
