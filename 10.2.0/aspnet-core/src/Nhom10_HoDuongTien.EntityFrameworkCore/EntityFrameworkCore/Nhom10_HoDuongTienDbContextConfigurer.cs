using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Nhom10_HoDuongTien.EntityFrameworkCore;

public static class Nhom10_HoDuongTienDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<Nhom10_HoDuongTienDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<Nhom10_HoDuongTienDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
