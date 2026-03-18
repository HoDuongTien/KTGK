using Abp.Web.Security.AntiForgery;
using Nhom10_HoDuongTien.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace Nhom10_HoDuongTien.Web.Host.Controllers
{
    public class AntiForgeryController : Nhom10_HoDuongTienControllerBase
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAntiforgery antiforgery, IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
