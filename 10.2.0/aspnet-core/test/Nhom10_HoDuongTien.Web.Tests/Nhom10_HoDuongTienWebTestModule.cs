using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nhom10_HoDuongTien.EntityFrameworkCore;
using Nhom10_HoDuongTien.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Nhom10_HoDuongTien.Web.Tests;

[DependsOn(
    typeof(Nhom10_HoDuongTienWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class Nhom10_HoDuongTienWebTestModule : AbpModule
{
    public Nhom10_HoDuongTienWebTestModule(Nhom10_HoDuongTienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Nhom10_HoDuongTienWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(Nhom10_HoDuongTienWebMvcModule).Assembly);
    }
}