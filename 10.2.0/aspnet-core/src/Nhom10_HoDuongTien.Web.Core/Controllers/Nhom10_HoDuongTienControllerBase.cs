using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Nhom10_HoDuongTien.Controllers
{
    public abstract class Nhom10_HoDuongTienControllerBase : AbpController
    {
        protected Nhom10_HoDuongTienControllerBase()
        {
            LocalizationSourceName = Nhom10_HoDuongTienConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
