using Nhom10_HoDuongTien.Configuration.Dto;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
