using Localization.Resources.AbpUi;
using AnnexMigration.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace AnnexMigration;

[DependsOn(
    typeof(AnnexMigrationApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AnnexMigrationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AnnexMigrationHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AnnexMigrationResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
