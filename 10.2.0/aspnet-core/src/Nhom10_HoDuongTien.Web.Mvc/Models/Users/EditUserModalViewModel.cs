using Nhom10_HoDuongTien.Roles.Dto;
using Nhom10_HoDuongTien.Users.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Nhom10_HoDuongTien.Web.Models.Users;

public class EditUserModalViewModel
{
    public UserDto User { get; set; }

    public IReadOnlyList<RoleDto> Roles { get; set; }

    public bool UserIsInRole(RoleDto role)
    {
        return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
    }
}
