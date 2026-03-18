using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Abp.Zero.EntityFrameworkCore;
using Nhom10_HoDuongTien.EntityFrameworkCore;
using Nhom10_HoDuongTien.Tests.DependencyInjection;
using Castle.MicroKernel.Registration;
using NSubstitute;
using System;

namespace Nhom10_HoDuongTien.Tests;

[DependsOn(
    typeof(Nhom10_HoDuongTienApplicationModule),
    typeof(Nhom10_HoDuongTienEntityFrameworkModule),
    typeof(AbpTestBaseModule)
    )]
public class Nhom10_HoDuongTienTestModule : AbpModule
{
    public Nhom10_HoDuongTienTestModule(Nhom10_HoDuongTienEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
        Configuration.UnitOfWork.IsTransactional = false;

        // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
        Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

        // Use database for language management
        Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

        RegisterFakeService<AbpZeroDbMigrator<Nhom10_HoDuongTienDbContext>>();

        Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
    }

    public override void Initialize()
    {
        ServiceCollectionRegistrar.Register(IocManager);
    }

    private void RegisterFakeService<TService>() where TService : class
    {
        IocManager.IocContainer.Register(
            Component.For<TService>()
                .UsingFactoryMethod(() => Substitute.For<TService>())
                .LifestyleSingleton()
        );
    }
}
