using BTL_NMCNPM.Models;

namespace BTL_NMCNPM.Models
{
    public class tblNhanVien
    {
        public string? sMaNV { get; set; }
        public string? sMaTK { get; set; }
        public tblTaiKhoan tblTaiKhoan { get; set; }
        public ICollection<tblHoSoNhanVien> tblHoSoNhanVien { get; set; }
    }
}

