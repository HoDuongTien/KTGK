using Abp.Authorization;
using Nhom10_HoDuongTien.Authorization.Roles;
using Nhom10_HoDuongTien.Authorization.Users;

namespace Nhom10_HoDuongTien.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
