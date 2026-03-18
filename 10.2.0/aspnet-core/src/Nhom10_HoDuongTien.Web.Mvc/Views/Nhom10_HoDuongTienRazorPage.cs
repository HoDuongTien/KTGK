using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Nhom10_HoDuongTien.Web.Views;

public abstract class Nhom10_HoDuongTienRazorPage<TModel> : AbpRazorPage<TModel>
{
    [RazorInject]
    public IAbpSession AbpSession { get; set; }

    protected Nhom10_HoDuongTienRazorPage()
    {
        LocalizationSourceName = Nhom10_HoDuongTienConsts.LocalizationSourceName;
    }
}
