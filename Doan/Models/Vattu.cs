using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("VATTU")]
    public partial class Vattu
    {
        [Key]
        [Column("STT")]
        public int Stt { get; set; }
        [Required]
        [Column("MA_VAT_TU")]
        [StringLength(20)]
        public string MaVatTu { get; set; }
        [Required]
        [Column("NHOM_VAT_TU")]
        [StringLength(255)]
        public string NhomVatTu { get; set; }
        [Required]
        [Column("TEN_VAT_TU")]
        [StringLength(255)]
        public string TenVatTu { get; set; }
        [Column("MA_HIEU")]
        [StringLength(20)]
        public string MaHieu { get; set; }
        [Required]
        [Column("QUY_CACH")]
        [StringLength(20)]
        public string QuyCach { get; set; }
        [Required]
        [Column("HANG_SX")]
        [StringLength(255)]
        public string HangSx { get; set; }
        [Required]
        [Column("NUOC_SX")]
        [StringLength(255)]
        public string NuocSx { get; set; }
        [Required]
        [Column("DON_VI_TINH")]
        [StringLength(20)]
        public string DonViTinh { get; set; }
        [Column("DON_GIA")]
        public int? DonGia { get; set; }
        [Column("DON_GIA_BH")]
        public int? DonGiaBh { get; set; }
        [Column("TYLE_TT_BH")]
        public int? TyleTtBh { get; set; }
        [Column("SO_LUONG")]
        public int? SoLuong { get; set; }
        [Column("DANH_MUC")]
        [StringLength(100)]
        public string DanhMuc { get; set; }
        [Required]
        [Column("NHA_THAU")]
        [StringLength(100)]
        public string NhaThau { get; set; }
        [Required]
        [Column("TT_THAU")]
        [StringLength(100)]
        public string TtThau { get; set; }
        [Column("TU_NGAY")]
        [StringLength(8)]
        public string TuNgay { get; set; }
        [Column("DEN_NGAY")]
        [StringLength(8)]
        public string DenNgay { get; set; }
        [Column("MA_CSKCB")]
        [StringLength(5)]
        public string MaCskcb { get; set; }
        [Required]
        [Column("LOAI_THAU")]
        [StringLength(1)]
        public string LoaiThau { get; set; }
        [Required]
        [Column("HT_THAU")]
        [StringLength(1)]
        public string HtThau { get; set; }
        [Required]
        [Column("ID")]
        [StringLength(8)]
        public string Id { get; set; }

        [ForeignKey(nameof(MaCskcb))]
        [InverseProperty(nameof(Cskcb.Vattu))]
        public virtual Cskcb MaCskcbNavigation { get; set; }
    }
}
