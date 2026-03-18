using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Nhom10_HoDuongTien.EntityFrameworkCore.Seed;

namespace Nhom10_HoDuongTien.EntityFrameworkCore;

[DependsOn(
    typeof(Nhom10_HoDuongTienCoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class Nhom10_HoDuongTienEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<Nhom10_HoDuongTienDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    Nhom10_HoDuongTienDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    Nhom10_HoDuongTienDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Nhom10_HoDuongTienEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
