using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AnnexMigration;

[DependsOn(
    typeof(AnnexMigrationApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AnnexMigrationHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AnnexMigrationApplicationContractsModule).Assembly,
            AnnexMigrationRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AnnexMigrationHttpApiClientModule>();
        });

    }
}
