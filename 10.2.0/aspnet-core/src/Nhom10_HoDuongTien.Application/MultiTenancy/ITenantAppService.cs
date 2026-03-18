using Abp.Application.Services;
using Nhom10_HoDuongTien.MultiTenancy.Dto;

namespace Nhom10_HoDuongTien.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

