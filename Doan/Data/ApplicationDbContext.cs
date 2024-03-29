using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Doan.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Doan.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cskcb> Cskcb { get; set; }
        public virtual DbSet<Dichvu> Dichvu { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Taikhoanquantri> Taikhoanquantri { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }
        public virtual DbSet<Vattu> Vattu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI;Database=doan;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cskcb>(entity =>
            {
                entity.HasKey(e => e.MaCskcb)
                    .HasName("PK__CSKCB__CD04CE7BF19E4AC5");

                entity.Property(e => e.MaCskcb).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.Stt).ValueGeneratedOnAdd();

                entity.Property(e => e.TaiKhoan).IsUnicode(false);
            });

            modelBuilder.Entity<Dichvu>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__DICHVU__CA1EB6901E6337BC");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.MaCskcb).IsUnicode(false);

                entity.Property(e => e.MaDichVu).IsUnicode(false);

                entity.Property(e => e.QuyTrinh).IsUnicode(false);

                entity.HasOne(d => d.MaCskcbNavigation)
                    .WithMany(p => p.Dichvu)
                    .HasForeignKey(d => d.MaCskcb)
                    .HasConstraintName("FK__DICHVU__MA_CSKCB__4BAC3F29");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__NHANVIEN__CA1EB690011499D0");

                entity.Property(e => e.MaBhxh).IsUnicode(false);

                entity.Property(e => e.MaCskcb).IsUnicode(false);

                entity.Property(e => e.MaKhoa).IsUnicode(false);

                entity.Property(e => e.Macchn).IsUnicode(false);

                entity.HasOne(d => d.MaCskcbNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.MaCskcb)
                    .HasConstraintName("FK__NHANVIEN__MA_CSK__412EB0B6");
            });

            modelBuilder.Entity<Taikhoanquantri>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__TAIKHOAN__CA1EB6900854919A");

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.TaiKhoan).IsUnicode(false);
            });

            modelBuilder.Entity<Thuoc>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__THUOC__CA1EB6900E10825C");

                entity.Property(e => e.DenNgay).IsUnicode(false);

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.DonGiaBh).HasDefaultValueSql("((0))");

                entity.Property(e => e.HtThau).IsUnicode(false);

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.LoaiThau).IsUnicode(false);

                entity.Property(e => e.LoaiThuoc).IsUnicode(false);

                entity.Property(e => e.MaCskcb).IsUnicode(false);

                entity.Property(e => e.MaDuongLuong).IsUnicode(false);

                entity.Property(e => e.MaThuoc).IsUnicode(false);

                entity.Property(e => e.NhaThau).IsUnicode(false);

                entity.Property(e => e.SoDangKy).IsUnicode(false);

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TenHoatChat).IsUnicode(false);

                entity.Property(e => e.TuNgay).IsUnicode(false);

                entity.HasOne(d => d.MaCskcbNavigation)
                    .WithMany(p => p.Thuoc)
                    .HasForeignKey(d => d.MaCskcb)
                    .HasConstraintName("FK__THUOC__MA_CSKCB__3C69FB99");
            });

            modelBuilder.Entity<Vattu>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__VATTU__CA1EB690839364B5");

                entity.Property(e => e.DenNgay).IsUnicode(false);

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.DonGiaBh).HasDefaultValueSql("((0))");

                entity.Property(e => e.HtThau).IsUnicode(false);

                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.LoaiThau).IsUnicode(false);

                entity.Property(e => e.MaCskcb).IsUnicode(false);

                entity.Property(e => e.MaHieu).IsUnicode(false);

                entity.Property(e => e.MaVatTu).IsUnicode(false);

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TtThau).IsUnicode(false);

                entity.Property(e => e.TuNgay).IsUnicode(false);

                entity.Property(e => e.TyleTtBh).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaCskcbNavigation)
                    .WithMany(p => p.Vattu)
                    .HasForeignKey(d => d.MaCskcb)
                    .HasConstraintName("FK__VATTU__MA_CSKCB__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
