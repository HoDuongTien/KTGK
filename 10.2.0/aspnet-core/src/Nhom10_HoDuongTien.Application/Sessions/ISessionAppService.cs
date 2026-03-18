using Abp.Application.Services;
using Nhom10_HoDuongTien.Sessions.Dto;
using System.Threading.Tasks;

namespace Nhom10_HoDuongTien.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
