using Abp.Authorization;
using Abp.Domain.Uow;
using Nhom10_HoDuongTien.Authorization.Roles;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Nhom10_HoDuongTien.Identity;

public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
{
    public SecurityStampValidator(
        IOptions<SecurityStampValidatorOptions> options,
        SignInManager signInManager,
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager)
        : base(options, signInManager, loggerFactory, unitOfWorkManager)
    {
    }
}
