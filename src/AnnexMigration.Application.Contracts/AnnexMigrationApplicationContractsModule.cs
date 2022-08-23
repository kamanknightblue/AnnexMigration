using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace AnnexMigration;

[DependsOn(
    typeof(AnnexMigrationDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AnnexMigrationApplicationContractsModule : AbpModule
{

}
