using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Nhom10_HoDuongTien.Authorization.Roles;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.Configuration;
using Nhom10_HoDuongTien.Localization;
using Nhom10_HoDuongTien.MultiTenancy;
using Nhom10_HoDuongTien.Timing;

namespace Nhom10_HoDuongTien;

[DependsOn(typeof(AbpZeroCoreModule))]
public class Nhom10_HoDuongTienCoreModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Auditing.IsEnabledForAnonymousUsers = true;

        // Declare entity types
        Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
        Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
        Configuration.Modules.Zero().EntityTypes.User = typeof(User);

        Nhom10_HoDuongTienLocalizationConfigurer.Configure(Configuration.Localization);

        // Enable this line to create a multi-tenant application.
        Configuration.MultiTenancy.IsEnabled = Nhom10_HoDuongTienConsts.MultiTenancyEnabled;

        // Configure roles
        AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

        Configuration.Settings.Providers.Add<AppSettingProvider>();

        Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));

        Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = Nhom10_HoDuongTienConsts.DefaultPassPhrase;
        SimpleStringCipher.DefaultPassPhrase = Nhom10_HoDuongTienConsts.DefaultPassPhrase;
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Nhom10_HoDuongTienCoreModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
    }
}
