using AnnexMigration.Localization;
using Volo.Abp.Application.Services;

namespace AnnexMigration;

public abstract class AnnexMigrationAppService : ApplicationService
{
    protected AnnexMigrationAppService()
    {
        LocalizationResource = typeof(AnnexMigrationResource);
        ObjectMapperContext = typeof(AnnexMigrationApplicationModule);
    }
}
