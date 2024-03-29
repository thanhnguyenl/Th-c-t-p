using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        [Key]
        [Column("STT")]
        public int Stt { get; set; }
        [Column("MA_LOAI_KCB")]
        [StringLength(10)]
        public String MaLoaiKcb { get; set; }
        [Required]
        [Column("MA_KHOA")]
        [StringLength(10)]
        public string MaKhoa { get; set; }
        [Required]
        [Column("MA_BHXH")]
        [StringLength(10)]
        public string MaBhxh { get; set; }
        [Required]
        [Column("HO_TEN")]
        [StringLength(100)]
        public string HoTen { get; set; }
        [Required]
        [Column("MACCHN")]
        [StringLength(30)]
        public string Macchn { get; set; }
        [Column("MA_CSKCB")]
        [StringLength(5)]
        public string MaCskcb { get; set; }

        [ForeignKey(nameof(MaCskcb))]
        [InverseProperty(nameof(Cskcb.Nhanvien))]
        public virtual Cskcb MaCskcbNavigation { get; set; }
    }
}
