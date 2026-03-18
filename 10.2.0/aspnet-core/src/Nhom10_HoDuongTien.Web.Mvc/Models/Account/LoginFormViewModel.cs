using Abp.MultiTenancy;

namespace Nhom10_HoDuongTien.Web.Models.Account;

public class LoginFormViewModel
{
    public string ReturnUrl { get; set; }

    public bool IsMultiTenancyEnabled { get; set; }

    public bool IsSelfRegistrationAllowed { get; set; }

    public MultiTenancySides MultiTenancySide { get; set; }
}
