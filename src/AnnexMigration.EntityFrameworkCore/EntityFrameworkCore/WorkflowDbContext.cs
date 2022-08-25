using AnnexMigration.Materials;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

/*
 * 工作流数据库上下文
 */
namespace AnnexMigration.EntityFrameworkCore
{
    /// <summary>
    /// 工作流数据库上下文
    /// </summary>
    [ConnectionStringName(AnnexMigrationDbProperties.WorkflowConnectionStringName)]
    public class WorkflowDbContext : AbpDbContext<WorkflowDbContext>
    {
        /// <summary>
        /// 材料
        /// </summary>
        public DbSet<Material> Materials { set; get; }

        /// <summary>
        /// 案卷材料
        /// </summary>
        public DbSet<CaseMaterial> CaseMaterials { set; get; }

        /// <summary>
        /// 案卷附件
        /// </summary>
        public DbSet<CaseAnnex> CaseAnnexes { set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="options">数据库上下文配置</param>
        public WorkflowDbContext(DbContextOptions<WorkflowDbContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// 配置数据模型
        /// </summary>
        /// <param name="modelBuilder">数据模型构造器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string GetTableName(string tableName)
            {
                return $"Workflow{tableName}".ToSnakeCase();
            }
            modelBuilder.Entity<Material>(p =>
            {
                p.ToTable($"{GetTableName(nameof(WorkflowDbContext.Materials))}");
                //p.HasOne(p => p.Template).WithMany().HasForeignKey(p => p.TemplateId).IsRequired();
                //p.HasMany(p => p.Activities).WithMany(p => p.Materials).UsingEntity(p => p.ToTable($"{GetTableName("ActivityMaterials")}", null));
                p.Property(p => p.MaterialId).IsRequired();
                p.Property(p => p.MaterialName).IsRequired();
                p.ConfigureByConventionWithSnakeCase();
            });

            modelBuilder.Entity<CaseMaterial>(p =>
            {
                p.ToTable($"{GetTableName(nameof(WorkflowDbContext.CaseMaterials))}");
                p.Property(p => p.Name).IsRequired();
                //p.HasOne(p => p.Template).WithMany().HasForeignKey(p => p.TemplateId).IsRequired();
                //p.HasMany(p => p.Activities).WithMany(p => p.CaseMaterials).UsingEntity(p => p.ToTable($"{GetTableName("ActivityCaseMaterials")}", null));
                //p.HasMany(p => p.Annexes).WithOne(p => p.Material).HasForeignKey(p => p.MaterialId).IsRequired();
                p.ConfigureByConventionWithSnakeCase();
            });

            modelBuilder.Entity<CaseAnnex>(p =>
            {
                p.ToTable($"{GetTableName(nameof(WorkflowDbContext.CaseAnnexes))}");
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.ContainerName).IsRequired();
                p.ConfigureByConventionWithSnakeCase();
            });
        }
    }
}