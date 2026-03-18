using System.ComponentModel.DataAnnotations;

namespace Nhom10_HoDuongTien.Configuration.Dto;

public class ChangeUiThemeInput
{
    [Required]
    [StringLength(32)]
    public string Theme { get; set; }
}
