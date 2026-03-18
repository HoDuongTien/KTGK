using Abp.AspNetCore.Mvc.ViewComponents;

namespace Nhom10_HoDuongTien.Web.Views;

public abstract class Nhom10_HoDuongTienViewComponent : AbpViewComponent
{
    protected Nhom10_HoDuongTienViewComponent()
    {
        LocalizationSourceName = Nhom10_HoDuongTienConsts.LocalizationSourceName;
    }
}
