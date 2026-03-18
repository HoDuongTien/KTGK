using System.ComponentModel.DataAnnotations;

namespace Nhom10_HoDuongTien.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}