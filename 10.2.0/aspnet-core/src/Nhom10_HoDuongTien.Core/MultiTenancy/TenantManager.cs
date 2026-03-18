using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Nhom10_HoDuongTien.Authorization.Users;
using Nhom10_HoDuongTien.Editions;

namespace Nhom10_HoDuongTien.MultiTenancy;

public class TenantManager : AbpTenantManager<Tenant, User>
{
    public TenantManager(
        IRepository<Tenant> tenantRepository,
        IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
        EditionManager editionManager,
        IAbpZeroFeatureValueStore featureValueStore)
        : base(
            tenantRepository,
            tenantFeatureRepository,
            editionManager,
            featureValueStore)
    {
    }
}
