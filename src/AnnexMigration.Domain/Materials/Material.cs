using System;
using Volo.Abp.Domain.Entities.Auditing;

/// <summary>
/// 流程材料
/// </summary>
namespace AnnexMigration.Materials
{
    /// <summary>
    /// 流程材料
    /// </summary>
    public class Material : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 流程ID
        /// 原字段名：TIID
        /// </summary>
        public virtual Guid TemplateId { get; protected set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public virtual string TemplateName { get; protected set; }

        /// <summary>
        /// 材料编号，自动生成
        /// </summary>
        public virtual int MaterialId { get; protected set; }

        /// <summary>
        /// 材料列表名称
        /// </summary>
        public virtual string MaterialName { get; protected set; }

        /// <summary>
        /// 子类型
        /// </summary>
        public virtual string SubType { get; protected set; }

        /// <summary>
        /// 是否必须
        /// </summary>
        public virtual bool Must { get; protected set; }

        /// <summary>
        /// 是否原件
        /// </summary>
        public virtual bool Original { get; protected set; }

        /// <summary>
        /// 是否签收
        /// </summary>
        public virtual bool Sign { get; protected set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public virtual int OrderId { get; protected set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; protected set; }

        /// <summary>
        /// 初始化
        /// </summary>
        protected Material()
        {
        }
    }
}
