using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien;

/// <summary>
/// Derive your application services from this class.
/// </summary>
public abstract class Nhom10_HoDuongTienAppServiceBase : ApplicationService
{
    public TenantManager TenantManager { get; set; }

    public UserManager UserManager { get; set; }

    protected Nhom10_HoDuongTienAppServiceBase()
    {
        LocalizationSourceName = Nhom10_HoDuongTienConsts.LocalizationSourceName;
    }

    protected virtual async Task<User> GetCurrentUserAsync()
    {
        var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
        if (user == null)
        {
            throw new Exception("There is no current user!");
        }

        return user;
    }

    protected virtual Task<Tenant> GetCurrentTenantAsync()
    {
        return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
    }

    protected virtual void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(LocalizationManager);
    }
}
