using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblThongBao
    {
        [Key]
        public string? sMaThongbao { get; set; }

        public string? sMaNV { get; set; }

        public DateTime? dNgayThongbao { get; set; }

        public string? sNoidung { get; set; }

        [ForeignKey("sMaNV")]
        public virtual tblNhanVien tblNhanVien { get; set; }
    }
}
