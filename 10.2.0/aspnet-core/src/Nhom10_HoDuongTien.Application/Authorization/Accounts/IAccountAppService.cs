using Abp.Application.Services;
using Nhom10_HoDuongTien.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
