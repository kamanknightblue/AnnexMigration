using AnnexMigration.FUpfiles;
using AnnexMigration.Materials;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace AnnexMigration.Annexes
{
    /// <summary>
    /// 迁移附件表信息
    /// </summary>
    public class MigrateAppService : AnnexMigrationAppService, IAnnexAppService
    {
        /// <summary>
        /// 审计属性设置器
        /// </summary>
        private readonly IAuditPropertySetter auditPropertySetter;

        private readonly IRepository<FUpfile> fupfileRepository;
        private readonly IRepository<FCasematerial> fCasematerialRepository;
        private readonly ILogger logger;
        private readonly IRepository<CaseMaterial, Guid> caseMaterialRepository;
        private readonly IRepository<CaseAnnex, Guid> caseAnnexRepository;
        private readonly IRepository<Annex, Guid> ossObjectRepository;
        /// <summary>
        /// 初始化
        /// </summary>
        public MigrateAppService(IRepository<FUpfile> fupfileRepository, ILogger<MigrateAppService> logger, IRepository<FCasematerial> fCasematerialRepository, IRepository<CaseMaterial, Guid> caseMaterialRepository, IRepository<CaseAnnex, Guid> caseAnnexRepository, IRepository<Annex, Guid> ossObjectRepository, IAuditPropertySetter auditPropertySetter)
        {
            this.fupfileRepository = fupfileRepository;
            this.logger = logger;
            this.fCasematerialRepository = fCasematerialRepository;
            this.caseMaterialRepository = caseMaterialRepository;
            this.caseAnnexRepository = caseAnnexRepository;
            this.ossObjectRepository = ossObjectRepository;
            this.auditPropertySetter = auditPropertySetter;
        }

        /// <summary>
        /// 迁移 F_UPFILES 表信息到 mongodb 和 workflow_case_annexes表
        /// </summary>
        public async Task<bool> CaseAnnexAsync()
        {
            logger.LogInformation($"Starting:迁移 F_UPFILES 表信息到 mongodb 和 workflow_case_annexes表。。。");
            //用于记录已经迁移的条数
            var count = 0;
            // 分页推送，每次推送的数据数量
            var pageSize = 1000;
            // F_UPFILES 表总记录数
            var fupfileCount = await fupfileRepository.GetCountAsync();
            // 总页数
            var pageCount = fupfileCount % pageSize != 0 ? fupfileCount / pageSize + 1 : fupfileCount / pageSize;
            // 保存 int 型 材料主键与 guid型 材料主键 映射关系
            var materialIds = new Dictionary<(int materialIntId, string caseNo), Guid>();
            // Oss对象的容器Id
            var containerId = new Guid("8401da37-3491-aa45-06be-39fffcdaea68");
            // 容器名
            var containerName = "Realestate";
            logger.LogInformation($"附件表有【{fupfileCount}】条数据需要迁移");

            // 分页推送
            for (var i = 0; i < pageCount; i++)
            {
                var fupfilePagedList = await fupfileRepository.GetPagedListAsync(skipCount: i * pageSize, maxResultCount: pageSize, sorting: nameof(FUpfile.Id));
                var newCaseAnnexes = new List<CaseAnnex>();
                var ossObjects = new List<Annex>();
                foreach (var fupfile in fupfilePagedList)
                {
                    // 插入mongodb中,生成oss对象
                    var ossObject = new Annex
                    {
                        Path = fupfile.Filepath,
                        Size = Convert.ToInt32(fupfile.Filesize),
                        ContainerId = containerId,
                        Name = fupfile.Filename
                    };
                    // 点的位置索引
                    var dotIndex = fupfile.Filename.LastIndexOf(".");
                    if (dotIndex != -1)
                    {
                        ossObject.ContentType = fupfile.Filename.Substring(dotIndex + 1);
                    }
                    EntityHelper.TrySetId(ossObject, () => GuidGenerator.Create());
                    auditPropertySetter.SetCreationProperties(ossObject);
                    ossObjects.Add(ossObject);

                    // 插入附件表
                    var caseAnnex = new CaseAnnex
                    {
                        Name = fupfile.Filename,
                        MaterialId = await GetMaterialGuidAsync(fupfile.Materialid, fupfile.Caseno, materialIds),
                        ContainerName = containerName,
                        ObjectId = ossObject.Id,
                        OrderNo = fupfile.Fileno
                    };
                    EntityHelper.TrySetId(caseAnnex, () => GuidGenerator.Create());
                    newCaseAnnexes.Add(caseAnnex);
                }
                count += fupfilePagedList.Count;
                await caseAnnexRepository.InsertManyAsync(newCaseAnnexes);
                await ossObjectRepository.InsertManyAsync(ossObjects);
                logger.LogInformation($"附件表迁移进度【{(count / (decimal)fupfileCount) * 100}%】");
                newCaseAnnexes.Clear();
                ossObjects.Clear();
            }
            logger.LogInformation($"Completed:迁移 F_UPFILES 表信息到 mongodb 和 workflow_case_annexes表。。。");
            return true;
        }

        /// <summary>
        /// 陈佳 8-31 15:33:01        原来的材料表的id只是一个自增的id，材料和附件是用caseno+materialid关联的
        /// 陈佳 8-31 15:33:30        你可以在材料表加一个guid的主键，迁移的时候用这个guid作为id迁移
        /// 陈佳 8-31 15:34:02        迁移附件的时候通过caseno+materialid关联材料表获取到这个guid，作为materialid迁移
        /// </summary>
        private async Task<Guid> GetMaterialGuidAsync(int materialIntId, string caseNo, Dictionary<(int materialIntId, string caseNo), Guid> materialIds)
        {
            var materialIntIdKeyName = "MaterialIntId";
            var caseNoKeyName = "CaseNo";
            if (materialIds.ContainsKey((materialIntId, caseNo)))
            {
                return materialIds[(materialIntId, caseNo)];
            }

            var totalCount = await caseMaterialRepository.GetCountAsync();
            var pageSize = 1000;
            var pageCount = totalCount % pageSize != 0 ? totalCount / pageSize + 1 : totalCount / pageSize;
            for (int i = 0; i < pageCount; i++)
            {
                var caseMaterials = await caseMaterialRepository.GetPagedListAsync(skipCount: materialIds.Count == 0 ? i * pageSize : materialIds.Count, maxResultCount: pageSize, sorting: nameof(CaseMaterial.Id));
                foreach (var caseMaterial in caseMaterials)
                {
                    if (!materialIds.ContainsKey((caseMaterial.GetProperty<int>(materialIntIdKeyName), caseMaterial.GetProperty<string>(caseNoKeyName))))
                    {
                        materialIds.Add((caseMaterial.GetProperty<int>(materialIntIdKeyName), caseMaterial.GetProperty<string>(caseNoKeyName)), caseMaterial.Id);
                    }
                    else
                    {
                        return materialIds[(caseMaterial.GetProperty<int>(materialIntIdKeyName), caseMaterial.GetProperty<string>(caseNoKeyName))];
                    }
                }
            }
            return Guid.Empty;
        }

        /// <summary>
        /// 迁移 F_CASEMATERIAL 到 workflow_case_materials
        /// </summary>
        public async Task<bool> CaseMaterialAsync()
        {
            // 先插入材料表
            logger.LogInformation($"Starting:迁移 F_CASEMATERIAL 到 workflow_case_materials。。。");
            // F_CASEMATERIAL 表 数据总量
            var totalFCaseMaterialCount = await fCasematerialRepository.GetCountAsync();
            // 分页推送数据，每页数据量大小
            var pageSize = 1000;
            // 页总数
            var pageCount = totalFCaseMaterialCount % pageSize != 0 ? totalFCaseMaterialCount / pageSize + 1 : totalFCaseMaterialCount / pageSize;
            // 模板Id不好获取，随便传，后边到数据库里再处理
            var templateId = new Guid("55cdf401-9b89-e1a1-cfde-3a003497cc22");
            // 记录已经推送的数据量
            var pushedCount = 0;

            logger.LogInformation($"材料表 F_CASEMATERIAL 有【{totalFCaseMaterialCount}】条数据需要迁移到 workflow_case_materials");
            for (int i = 0; i < pageCount; i++)
            {
                var fCaseMaterialList = await fCasematerialRepository.GetPagedListAsync(skipCount: i * pageSize, maxResultCount: pageSize, sorting: nameof(FCasematerial.Id));
                var caseMaterialList = new List<CaseMaterial>();
                foreach (var caseMaterial in fCaseMaterialList)
                {
                    var newCaseMaterial = new CaseMaterial
                    {
                        CaseNo = caseMaterial.Caseno,
                        CaseTitle = caseMaterial.Casetitle,
                        Name = caseMaterial.Materialname,
                        SubType = caseMaterial.Subtype,
                        Required = caseMaterial.Must == 1,
                        Original = caseMaterial.Original == 1,
                        Sign = caseMaterial.Sign == 1,
                        OrderNo = caseMaterial.Orderid,
                        Pages = caseMaterial.Copies,
                        TemplateId = templateId
                    };
                    EntityHelper.TrySetId(newCaseMaterial, () => GuidGenerator.Create());
                    newCaseMaterial.SetProperty("CaseNo", caseMaterial.Caseno);
                    newCaseMaterial.SetProperty("MaterialIntId", caseMaterial.Materialid);
                    caseMaterialList.Add(newCaseMaterial);
                }
                await caseMaterialRepository.InsertManyAsync(caseMaterialList);
                pushedCount += fCaseMaterialList.Count;
                logger.LogInformation($"迁移 F_CASEMATERIAL 到 workflow_case_materials 进度为【{(pushedCount / (decimal)totalFCaseMaterialCount) * 100}】%");
            }
            logger.LogInformation($"Compeleted:迁移 F_CASEMATERIAL 到 workflow_case_materials。。。");
            return true;
        }
    }
}
