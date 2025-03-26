namespace BTL_NMCNPM.Models
{
    public class tblHoSoNhanVien
    {
        public int iMaHoSoNV { get; set; }
        public string? sMaNV { get; set; }
        public string? sTenNV { get; set; }
        public string? sEmail { get; set; }
        public int? iCCCD { get; set; }
        public DateTime? dNgaysinh { get; set; }
        public int? iSDT { get; set; }
        public string? sDiachi { get; set; }
        public string? sHocvan { get; set; }
        public string? sKinhnghiem { get; set; }
        public tblNhanVien tblNhanVien { get; set; }

        // Thêm thuộc tính này để thiết lập quan hệ nhiều
        public ICollection<tblDanhSachUngTuyen>? tblDanhSachUngTuyen { get; set; }
        
    }
}
