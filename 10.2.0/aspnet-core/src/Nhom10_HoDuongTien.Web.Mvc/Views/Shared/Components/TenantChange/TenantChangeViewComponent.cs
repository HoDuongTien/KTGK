using Abp.ObjectMapping;
using Nhom10_HoDuongTien.Sessions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Web.Views.Shared.Components.TenantChange;

public class TenantChangeViewComponent : Nhom10_HoDuongTienViewComponent
{
    private readonly ISessionAppService _sessionAppService;
    private readonly IObjectMapper _objectMapper;

    public TenantChangeViewComponent(ISessionAppService sessionAppService, IObjectMapper objectMapper)
    {
        _sessionAppService = sessionAppService;
        _objectMapper = objectMapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
        var model = _objectMapper.Map<TenantChangeViewModel>(loginInfo);
        return View(model);
    }
}
