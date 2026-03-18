using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Nhom10_HoDuongTien.Configuration;
using Nhom10_HoDuongTien.EntityFrameworkCore;
using Nhom10_HoDuongTien.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace Nhom10_HoDuongTien.Migrator;

[DependsOn(typeof(Nhom10_HoDuongTienEntityFrameworkModule))]
public class Nhom10_HoDuongTienMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public Nhom10_HoDuongTienMigratorModule(Nhom10_HoDuongTienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(Nhom10_HoDuongTienMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            Nhom10_HoDuongTienConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Nhom10_HoDuongTienMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
