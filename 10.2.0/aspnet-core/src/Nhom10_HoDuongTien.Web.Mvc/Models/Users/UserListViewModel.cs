using Nhom10_HoDuongTien.Roles.Dto;
using System.Collections.Generic;

namespace Nhom10_HoDuongTien.Web.Models.Users;

public class UserListViewModel
{
    public IReadOnlyList<RoleDto> Roles { get; set; }
}
