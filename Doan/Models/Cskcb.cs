using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("CSKCB")]
    public partial class Cskcb
    {
        public Cskcb()
        {
            Dichvu = new HashSet<Dichvu>();
            Nhanvien = new HashSet<Nhanvien>();
            Thuoc = new HashSet<Thuoc>();
            Vattu = new HashSet<Vattu>();
        }

        [Key]
        [Column("MA_CSKCB")]
        [StringLength(5)]
        public string MaCskcb { get; set; }
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

        [InverseProperty("MaCskcbNavigation")]
        public virtual ICollection<Dichvu> Dichvu { get; set; }
        [InverseProperty("MaCskcbNavigation")]
        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
        [InverseProperty("MaCskcbNavigation")]
        public virtual ICollection<Thuoc> Thuoc { get; set; }
        [InverseProperty("MaCskcbNavigation")]
        public virtual ICollection<Vattu> Vattu { get; set; }
    }
}
