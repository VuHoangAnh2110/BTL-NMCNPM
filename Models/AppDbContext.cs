using BTL_NMCNPM.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_NMCNPM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HOSONHANVIEN> HOSONHANVIEN { get; set; }
        public DbSet<tblTaiKhoan> tblTaiKhoan { get; set; }
        public DbSet<tblNhanVien> tblNhanVien { get; set; }
        public DbSet<tblHoSoNhanVien> tblHoSoNhanVien { get; set; }
        public DbSet<tblThongTinTuyenDung> tblThongTinTuyenDung { get; set; }
        public DbSet<tblThongBao> tblThongBao { get; set; }
        public DbSet<tblDanhSachUngTuyen> tblDanhSachUngTuyen { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblNhanVien>()
                .HasOne(nv => nv.tblTaiKhoan)
                .WithMany(tk => tk.tblNhanVien)
                .HasForeignKey(nv => nv.sMaTK);

            modelBuilder.Entity<tblHoSoNhanVien>()
                .HasOne(hs => hs.tblNhanVien)
                .WithMany(nv => nv.tblHoSoNhanVien)
                .HasForeignKey(hs => hs.sMaNV);

            // modelBuilder.Entity<tblDanhSachUngTuyen>()
            //     .HasOne(d => d.tblHoSoNhanVien)
            //     .WithMany(hs => hs.tblDanhSachUngTuyen)
            //     .HasForeignKey(d => d.sMaNV);

        }
    }
}
