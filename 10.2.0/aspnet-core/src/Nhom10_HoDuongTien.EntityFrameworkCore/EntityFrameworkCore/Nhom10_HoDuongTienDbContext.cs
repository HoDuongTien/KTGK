using Abp.Zero.EntityFrameworkCore;
using Nhom10_HoDuongTien.Authorization.Roles;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Nhom10_HoDuongTien.Core.Entities.Toeic;
namespace Nhom10_HoDuongTien.EntityFrameworkCore;

public class Nhom10_HoDuongTienDbContext : AbpZeroDbContext<Tenant, Role, User, Nhom10_HoDuongTienDbContext>
{
    /* Define a DbSet for each entity of the application */
     public DbSet<DeThi> DeThis { get; set; }
    public DbSet<PhanThi> PhanThis { get; set; }
    public DbSet<DoanVan> DoanVans { get; set; }
    public DbSet<CauHoi> CauHois { get; set; }
    public DbSet<LuaChon> LuaChons { get; set; }
    public DbSet<CauTraLoiNguoiDung> CauTraLoiNguoiDungs { get; set; }
    public Nhom10_HoDuongTienDbContext(DbContextOptions<Nhom10_HoDuongTienDbContext> options)
        : base(options)
    {
    }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // FIX lỗi multiple cascade paths
        modelBuilder.Entity<CauTraLoiNguoiDung>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CauTraLoiNguoiDung>()
            .HasOne<CauHoi>()
            .WithMany()
            .HasForeignKey(x => x.CauHoiId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CauTraLoiNguoiDung>()
            .HasOne<LuaChon>()
            .WithMany()
            .HasForeignKey(x => x.LuaChonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
