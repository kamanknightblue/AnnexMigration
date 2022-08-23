using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AnnexMigration.EntityFrameworkCore;

[ConnectionStringName(AnnexMigrationDbProperties.ConnectionStringName)]
public class AnnexMigrationDbContext : AbpDbContext<AnnexMigrationDbContext>, IAnnexMigrationDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AnnexMigrationDbContext(DbContextOptions<AnnexMigrationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAnnexMigration();
    }
}
