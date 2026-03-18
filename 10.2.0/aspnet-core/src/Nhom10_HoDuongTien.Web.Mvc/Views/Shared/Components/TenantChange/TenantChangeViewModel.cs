using Abp.AutoMapper;
using Nhom10_HoDuongTien.Sessions.Dto;

namespace Nhom10_HoDuongTien.Web.Views.Shared.Components.TenantChange;

[AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
public class TenantChangeViewModel
{
    public TenantLoginInfoDto Tenant { get; set; }
}
