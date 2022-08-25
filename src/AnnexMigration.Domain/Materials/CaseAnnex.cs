using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace AnnexMigration.Materials
{
    /// <summary>
    /// 案卷附件
    /// </summary>
    public class CaseAnnex : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { set; get; }

        /// <summary>
        /// 案卷材料 ID
        /// </summary>
        public virtual Guid MaterialId { set; get; }

        /// <summary>
        /// OSS 容器名称
        /// </summary>
        public virtual string ContainerName { set; get; }

        /// <summary>
        /// OSS 对象 ID
        /// </summary>
        public virtual Guid ObjectId { set; get; }

        /// <summary>
        /// 序号
        /// </summary>
        public virtual int? OrderNo { set; get; }


    }
}
