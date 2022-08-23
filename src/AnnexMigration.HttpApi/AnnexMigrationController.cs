using AnnexMigration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AnnexMigration;

public abstract class AnnexMigrationController : AbpControllerBase
{
    protected AnnexMigrationController()
    {
        LocalizationResource = typeof(AnnexMigrationResource);
    }
}
