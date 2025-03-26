namespace BTL_NMCNPM.Models
{
    public class tblTaiKhoan
    {
        public string sMaTK { get; set; }
        public string sMaQuyen { get; set; }
        public string sTaiKhoan { get; set; }
        public string sMatKhau { get; set; }
        public string sTinhTrang { get; set; }
        public ICollection<tblNhanVien> tblNhanVien { get; set; }
    }
}
