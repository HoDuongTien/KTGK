using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nhom10_HoDuongTien.Authorization;

namespace Nhom10_HoDuongTien;

[DependsOn(
    typeof(Nhom10_HoDuongTienCoreModule),
    typeof(AbpAutoMapperModule))]
public class Nhom10_HoDuongTienApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<Nhom10_HoDuongTienAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(Nhom10_HoDuongTienApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
