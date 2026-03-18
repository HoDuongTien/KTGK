using Abp.MultiTenancy;
using Nhom10_HoDuongTien.Authorization.Users;

namespace Nhom10_HoDuongTien.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
