using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_NMCNPM.Models
{
    public class tblQuyenHan
    {
        [Key]
        public string sMaQuyen { get; set; }

        public string sTenQuyen { get; set; }

        public virtual ICollection<tblTaiKhoan> tblTaiKhoan { get; set; } = new HashSet<tblTaiKhoan>();
    }
}
