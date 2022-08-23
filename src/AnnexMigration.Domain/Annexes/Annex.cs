using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace AnnexMigration.Annexes
{
    public class Annex : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { set; get; }

        /// <summary>
        /// 大小
        /// </summary>
        public virtual int Size { set; get; }

        /// <summary>
        /// 内容类型
        /// </summary>
        public virtual string ContentType { set; get; }

        /// <summary>
        /// 容器id
        /// </summary>
        public virtual Guid ContainerId { set; get; }


        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { set; get; }

    }
}
