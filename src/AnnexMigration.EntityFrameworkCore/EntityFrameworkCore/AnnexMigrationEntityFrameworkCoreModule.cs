using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AnnexMigration.EntityFrameworkCore;

[DependsOn(
    typeof(AnnexMigrationDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AnnexMigrationEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AnnexMigrationDbContext>(options =>
        {
                options.AddDefaultRepositories(includeAllEntities:true);
        });
    }
}
