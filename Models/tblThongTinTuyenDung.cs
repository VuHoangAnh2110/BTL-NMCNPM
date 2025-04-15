using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    public class tblThongTinTuyenDung
    {
        [Key]
        public string? sMaTD { get; set; }

        public string? sDoituong { get; set; }

        public DateTime? dNgayyeucau { get; set; }

        public DateTime? dNgayhethan { get; set; }

        public string? sMotaTD { get; set; }

        public int? iMucluong { get; set; }

        public string? sDaingo { get; set; }

        public string? sNoilamviec { get; set; }

        public string? sVitri { get; set; }

        [InverseProperty("ThongTinTuyenDung")]
        public virtual ICollection<tblDanhSachUngTuyen> DanhSachUngTuyen { get; set; } = new List<tblDanhSachUngTuyen>();


    }
}
