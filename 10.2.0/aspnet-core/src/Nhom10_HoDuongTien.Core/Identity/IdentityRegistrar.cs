using Nhom10_HoDuongTien.Authorization;
using Nhom10_HoDuongTien.Authorization.Roles;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.Editions;
using Nhom10_HoDuongTien.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Nhom10_HoDuongTien.Identity;

public static class IdentityRegistrar
{
    public static IdentityBuilder Register(IServiceCollection services)
    {
        services.AddLogging();

        return services.AddAbpIdentity<Tenant, User, Role>()
            .AddAbpTenantManager<TenantManager>()
            .AddAbpUserManager<UserManager>()
            .AddAbpRoleManager<RoleManager>()
            .AddAbpEditionManager<EditionManager>()
            .AddAbpUserStore<UserStore>()
            .AddAbpRoleStore<RoleStore>()
            .AddAbpLogInManager<LogInManager>()
            .AddAbpSignInManager<SignInManager>()
            .AddAbpSecurityStampValidator<SecurityStampValidator>()
            .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
            .AddPermissionChecker<PermissionChecker>()
            .AddDefaultTokenProviders();
    }
}
