using Abp.Authorization;
using Abp.Runtime.Session;
using Nhom10_HoDuongTien.Configuration.Dto;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : Nhom10_HoDuongTienAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
