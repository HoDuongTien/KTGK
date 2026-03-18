using System.Collections.Generic;

namespace Nhom10_HoDuongTien.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
