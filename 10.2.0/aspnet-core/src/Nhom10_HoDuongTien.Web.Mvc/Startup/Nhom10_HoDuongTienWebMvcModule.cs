using Abp.Modules;
using Abp.Reflection.Extensions;
using Nhom10_HoDuongTien.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Nhom10_HoDuongTien.Web.Startup;

[DependsOn(typeof(Nhom10_HoDuongTienWebCoreModule))]
public class Nhom10_HoDuongTienWebMvcModule : AbpModule
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfigurationRoot _appConfiguration;

    public Nhom10_HoDuongTienWebMvcModule(IWebHostEnvironment env)
    {
        _env = env;
        _appConfiguration = env.GetAppConfiguration();
    }

    public override void PreInitialize()
    {
        Configuration.Navigation.Providers.Add<Nhom10_HoDuongTienNavigationProvider>();
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Nhom10_HoDuongTienWebMvcModule).GetAssembly());
    }
}
