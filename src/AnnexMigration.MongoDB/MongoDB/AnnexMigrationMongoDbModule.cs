using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace AnnexMigration.MongoDB;

[DependsOn(
    typeof(AnnexMigrationDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class AnnexMigrationMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<AnnexMigrationMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, MongoQuestionRepository>();
             * 
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
