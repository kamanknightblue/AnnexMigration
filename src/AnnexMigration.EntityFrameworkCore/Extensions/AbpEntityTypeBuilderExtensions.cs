using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Volo.Abp.EntityFrameworkCore.Modeling
{
    /// <summary>
    /// EntityTypeBuilder 扩展类
    /// </summary>
    public static class AbpEntityTypeBuilderExtensions
    {
        /// <summary>
        /// 按蛇形命名法修改 Abp 审计等字段映射
        /// </summary>
        /// <param name="b"></param>
        public static void ConfigureByConventionWithSnakeCase(this EntityTypeBuilder b)
        {
            b.ConfigureByConvention();
            var properties = new[] { "ExtraProperties", "ConcurrencyStamp", "CreationTime", "CreatorId", "LastModificationTime", "LastModifierId", "IsDeleted", "DeleterId", "DeletionTime" };
            foreach (var item in properties)
            {
                if (b.Metadata.ClrType.GetProperty(item) != null)
                {
                    b.Property(item).HasColumnName(item.ToSnakeCase());
                }
            }
        }
    }
}
