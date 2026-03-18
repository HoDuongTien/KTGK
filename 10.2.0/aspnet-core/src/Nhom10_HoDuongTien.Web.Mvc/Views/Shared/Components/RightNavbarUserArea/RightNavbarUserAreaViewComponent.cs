using Abp.Configuration.Startup;
using Nhom10_HoDuongTien.Sessions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Web.Views.Shared.Components.RightNavbarUserArea;

public class RightNavbarUserAreaViewComponent : Nhom10_HoDuongTienViewComponent
{
    private readonly ISessionAppService _sessionAppService;
    private readonly IMultiTenancyConfig _multiTenancyConfig;

    public RightNavbarUserAreaViewComponent(
        ISessionAppService sessionAppService,
        IMultiTenancyConfig multiTenancyConfig)
    {
        _sessionAppService = sessionAppService;
        _multiTenancyConfig = multiTenancyConfig;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new RightNavbarUserAreaViewModel
        {
            LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
        };

        return View(model);
    }
}

