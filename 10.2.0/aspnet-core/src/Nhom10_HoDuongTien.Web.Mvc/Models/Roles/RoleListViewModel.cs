using Nhom10_HoDuongTien.Roles.Dto;
using System.Collections.Generic;

namespace Nhom10_HoDuongTien.Web.Models.Roles;

public class RoleListViewModel
{
    public IReadOnlyList<PermissionDto> Permissions { get; set; }
}
