using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AnnexMigration.EntityFrameworkCore;

public class AnnexMigrationHttpApiHostMigrationsDbContext : AbpDbContext<AnnexMigrationHttpApiHostMigrationsDbContext>
{
    public AnnexMigrationHttpApiHostMigrationsDbContext(DbContextOptions<AnnexMigrationHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureAnnexMigration();
    }
}
