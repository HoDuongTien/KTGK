using Nhom10_HoDuongTien.Roles.Dto;
using System.Collections.Generic;

namespace Nhom10_HoDuongTien.Web.Models.Common;

public interface IPermissionsEditViewModel
{
    List<FlatPermissionDto> Permissions { get; set; }
}