using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AnnexMigration.Annexes
{
    public class AnnexAppService : AnnexMigrationAppService, IAnnexAppService
    {
        private readonly AnnexManager annexManager;
        private readonly IRepository<Annex, Guid> annexRepository;

        /// <summary>
        /// 初始化
        /// </summary>
        public AnnexAppService(AnnexManager annexManager)
        {
            this.annexManager = annexManager;
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">参数模型</param>
        /// <returns>新增操作结果</returns>
        public async Task<bool> InsertAsync(AnnexDto model)
        {
            var newEntity = ObjectMapper.Map<AnnexDto, Annex>(model);
            EntityHelper.TrySetId(newEntity, () => GuidGenerator.Create());
            await annexManager.CreateAnnex(newEntity);
            return true;
        }
    }
}
