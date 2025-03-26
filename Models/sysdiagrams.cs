using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_NMCNPM.Models
{
    [Table("sysdiagrams")]
    public class sysdiagrams
    {
        [Key]
        public int diagram_id { get; set; }

        [Required]
        public string name { get; set; }

        public int principal_id { get; set; }

        public int? version { get; set; }

        public byte[] definition { get; set; }
    }
}
