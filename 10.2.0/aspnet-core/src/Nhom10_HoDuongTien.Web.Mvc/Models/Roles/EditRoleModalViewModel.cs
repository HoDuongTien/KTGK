using Abp.AutoMapper;
using Nhom10_HoDuongTien.Roles.Dto;
using Nhom10_HoDuongTien.Web.Models.Common;

namespace Nhom10_HoDuongTien.Web.Models.Roles;

[AutoMapFrom(typeof(GetRoleForEditOutput))]
public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
{
    public bool HasPermission(FlatPermissionDto permission)
    {
        return GrantedPermissionNames.Contains(permission.Name);
    }
}
