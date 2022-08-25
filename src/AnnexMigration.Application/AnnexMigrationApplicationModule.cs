using AnnexMigration.Annexes;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace AnnexMigration;

[DependsOn(
    typeof(AnnexMigrationDomainModule),
    typeof(AnnexMigrationApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class AnnexMigrationApplicationModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        //AsyncHelper.RunSync(async () =>
        //{
        //    await context.AddBackgroundWorkerAsync<DataPushWorker>();
        //});
        //等价于：context.ServiceProvider.GetRequiredService<IBackgroundWorkerManager>().Add(context.ServiceProvider.GetRequiredService<PassiveUserCheckerWorker>());
        context.AddBackgroundWorkerAsync<DataPushWorker>().GetAwaiter().GetResult();
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AnnexMigrationApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AnnexMigrationApplicationModule>(validate: true);
        });
    }
}
