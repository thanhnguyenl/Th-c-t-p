using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Models
{
    [Table("THUOC")]
    public partial class Thuoc
    {
        [Key]
        [Column("STT")]
        public int Stt { get; set; }
        [Required]
        [Column("MA_THUOC")]
        [StringLength(10)]
        public string MaThuoc { get; set; }
        [Column("TEN_HOAT_CHAT")]
        [StringLength(100)]
        public string TenHoatChat { get; set; }
        [Column("TEN_THUOC")]
        [StringLength(100)]
        public string TenThuoc { get; set; }
        [Column("DON_VI_TINH")]
        [StringLength(20)]
        public string DonViTinh { get; set; }
        [Column("HAM_LUONG")]
        [StringLength(255)]
        public string HamLuong { get; set; }
        [Column("DUONG_LUONG")]
        [StringLength(20)]
        public string DuongLuong { get; set; }
        [Column("MA_DUONG_LUONG")]
        [StringLength(10)]
        public string MaDuongLuong { get; set; }
        [Column("DANG_BAO_CHE")]
        [StringLength(20)]
        public string DangBaoChe { get; set; }
        [Column("SO_DANG_KY")]
        [StringLength(20)]
        public string SoDangKy { get; set; }
        [Column("SO_LUONG")]
        public int? SoLuong { get; set; }
        [Column("DON_GIA")]
        public int? DonGia { get; set; }
        [Column("DON_GIA_BH")]
        public int? DonGiaBh { get; set; }
        [Column("QUY_CACH")]
        [StringLength(100)]
        public string QuyCach { get; set; }
        [Column("NHA_SX")]
        [StringLength(100)]
        public string NhaSx { get; set; }
        [Column("NUOC_SX")]
        [StringLength(100)]
        public string NuocSx { get; set; }
        [Column("NHA_THAU")]
        [StringLength(50)]
        public string NhaThau { get; set; }
        [Column("TT_THAU")]
        [StringLength(30)]
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
        [Column("LOAI_THUOC")]
        [StringLength(1)]
        public string LoaiThuoc { get; set; }
        [Column("LOAI_THAU")]
        [StringLength(1)]
        public string LoaiThau { get; set; }
        [Column("HT_THAU")]
        [StringLength(1)]
        public string HtThau { get; set; }
        [Column("MA_DVKT")]
        [StringLength(100)]
        public string MaDvkt { get; set; }
        [Column("TCCL")]
        [StringLength(100)]
        public string Tccl { get; set; }
        [Column("BO_PHAN_VT")]
        [StringLength(100)]
        public string BoPhanVt { get; set; }
        [Column("TEN_KHOA_HOC")]
        [StringLength(100)]
        public string TenKhoaHoc { get; set; }
        [Column("NGUON_GOC")]
        [StringLength(100)]
        public string NguonGoc { get; set; }
        [Column("PP_CHEBIEN")]
        [StringLength(100)]
        public string PpChebien { get; set; }
        [Column("MA_DL_NHAP")]
        [StringLength(100)]
        public string MaDlNhap { get; set; }
        [Column("MA_DL_CB")]
        [StringLength(100)]
        public string MaDlCb { get; set; }
        [Column("MA_TLHH_CB")]
        [StringLength(100)]
        public string MaTlhhCb { get; set; }
        [Column("TLHH_BQ")]
        [StringLength(100)]
        public string TlhhBq { get; set; }
        [Column("ID")]
        [StringLength(8)]
        public string Id { get; set; }

        [ForeignKey(nameof(MaCskcb))]
        [InverseProperty(nameof(Cskcb.Thuoc))]
        public virtual Cskcb MaCskcbNavigation { get; set; }
    }
}
