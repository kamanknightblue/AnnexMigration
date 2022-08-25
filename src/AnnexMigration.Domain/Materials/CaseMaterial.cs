using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace AnnexMigration.Materials
{
    /// <summary>
    /// 案卷材料
    /// </summary>
    public class CaseMaterial : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 案卷名称
        /// </summary>
        public virtual string CaseNo { set; get; }

        /// <summary>
        /// 案卷标题
        /// </summary>
        public virtual string CaseTitle { set; get; }

        /// <summary>
        /// 流程模板 ID
        /// </summary>
        public virtual Guid TemplateId { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { set; get; }

        /// <summary>
        /// 子类型
        /// </summary>
        public virtual string SubType { get; set; }

        /// <summary>
        /// 必传
        /// </summary>
        public virtual bool Required { set; get; }

        /// <summary>
        /// 原件
        /// </summary>
        public virtual bool Original { set; get; }

        /// <summary>
        /// 签收
        /// </summary>
        public virtual bool Sign { set; get; }

        /// <summary>
        /// 序号
        /// </summary>
        public virtual int OrderNo { set; get; }

        /// <summary>
        /// 页数
        /// </summary>
        public virtual int Pages { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { set; get; }
    }
}
