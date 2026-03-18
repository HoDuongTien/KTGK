using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Nhom10_HoDuongTien.Authorization;
using Nhom10_HoDuongTien.Controllers;
using Nhom10_HoDuongTien.Users;
using Nhom10_HoDuongTien.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Web.Controllers;

[AbpMvcAuthorize(PermissionNames.Pages_Users)]
public class UsersController : Nhom10_HoDuongTienControllerBase
{
    private readonly IUserAppService _userAppService;

    public UsersController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task<ActionResult> Index()
    {
        var roles = (await _userAppService.GetRoles()).Items;
        var model = new UserListViewModel
        {
            Roles = roles
        };
        return View(model);
    }

    public async Task<ActionResult> EditModal(long userId)
    {
        var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
        var roles = (await _userAppService.GetRoles()).Items;
        var model = new EditUserModalViewModel
        {
            User = user,
            Roles = roles
        };
        return PartialView("_EditModal", model);
    }

    public ActionResult ChangePassword()
    {
        return View();
    }
}
