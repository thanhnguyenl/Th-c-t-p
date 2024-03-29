using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("DICHVU")]
    public partial class Dichvu
    {
        [Key]
        [Column("STT")]
        public int Stt { get; set; }
        [Required]
        [Column("MA_DICH_VU")]
        [StringLength(20)]
        public string MaDichVu { get; set; }
        [Required]
        [Column("TEN_DICH_VU")]
        [StringLength(255)]
        public string TenDichVu { get; set; }
        [Column("DON_GIA")]
        public int? DonGia { get; set; }
        [Required]
        [Column("QUY_TRINH")]
        [StringLength(30)]
        public string QuyTrinh { get; set; }
        [Column("CSKCB_CGKT")]
        [StringLength(255)]
        public string CskcbCgkt { get; set; }
        [Column("CSKCB_CLS")]
        [StringLength(255)]
        public string CskcbCls { get; set; }
        [Required]
        [Column("ID")]
        [StringLength(8)]
        public string Id { get; set; }
        [Column("MA_CSKCB")]
        [StringLength(5)]
        public string MaCskcb { get; set; }

        [ForeignKey(nameof(MaCskcb))]
        [InverseProperty(nameof(Cskcb.Dichvu))]
        public virtual Cskcb MaCskcbNavigation { get; set; }
    }
}
