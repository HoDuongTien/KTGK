using Abp.AspNetCore.Mvc.Authorization;
using Nhom10_HoDuongTien.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Nhom10_HoDuongTien.Web.Controllers;

[AbpMvcAuthorize]
public class AboutController : Nhom10_HoDuongTienControllerBase
{
    public ActionResult Index()
    {
        return View();
    }
}
