using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AnnexMigration.EntityFrameworkCore;

[ConnectionStringName(AnnexMigrationDbProperties.ConnectionStringName)]
public interface IAnnexMigrationDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
