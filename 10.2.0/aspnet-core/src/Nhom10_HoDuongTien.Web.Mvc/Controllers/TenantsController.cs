using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Nhom10_HoDuongTien.Authorization;
using Nhom10_HoDuongTien.Controllers;
using Nhom10_HoDuongTien.MultiTenancy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Web.Controllers;

[AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
public class TenantsController : Nhom10_HoDuongTienControllerBase
{
    private readonly ITenantAppService _tenantAppService;

    public TenantsController(ITenantAppService tenantAppService)
    {
        _tenantAppService = tenantAppService;
    }

    public ActionResult Index() => View();

    public async Task<ActionResult> EditModal(int tenantId)
    {
        var tenantDto = await _tenantAppService.GetAsync(new EntityDto(tenantId));
        return PartialView("_EditModal", tenantDto);
    }
}
