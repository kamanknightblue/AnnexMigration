using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace AnnexMigration.Annexes
{
    /// <summary>
    ///  后台工作者
    /// </summary>
    public class DataPushWorker : BackgroundWorkerBase
    {
        /// <summary>
        /// 配置程序
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// 日志程序
        /// </summary>
        private readonly ILogger<DataPushWorker> logger;

        private readonly MigrateAppService annexAppService;

        /// <summary>
        /// 初始化
        /// </summary>
        public DataPushWorker(ILogger<DataPushWorker> logger, IConfiguration configuration, MigrateAppService annexAppService = null)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.annexAppService = annexAppService;
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        public override async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            await annexAppService.CaseMaterialAsync();
            await annexAppService.CaseAnnexAsync();
        }
    }
}
