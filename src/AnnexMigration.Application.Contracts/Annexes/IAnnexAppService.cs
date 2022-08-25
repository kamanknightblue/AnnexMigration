using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AnnexMigration.Annexes
{
    /// <summary>
    /// 管理服务接口
    /// </summary>
    public interface IAnnexAppService : IApplicationService
    {
        Task<bool> CaseAnnexAsync();
    }
}
