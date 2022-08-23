using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AnnexMigration;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AnnexMigrationDomainSharedModule)
)]
public class AnnexMigrationDomainModule : AbpModule
{

}
