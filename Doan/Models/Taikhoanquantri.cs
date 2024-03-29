using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("TAIKHOANQUANTRI")]
    public partial class Taikhoanquantri
    {
        [Key]
        [Column("STT")]
        public int Stt { get; set; }
        [Required]
        [Column("TAI_KHOAN")]
        [StringLength(30)]
        public string TaiKhoan { get; set; }
        [Required]
        [Column("MAT_KHAU")]
        [StringLength(20)]
        public string MatKhau { get; set; }
    }
}
