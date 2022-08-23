using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AnnexMigration.EntityFrameworkCore;

public class AnnexMigrationHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AnnexMigrationHttpApiHostMigrationsDbContext>
{
    public AnnexMigrationHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AnnexMigrationHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("AnnexMigration"));

        return new AnnexMigrationHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
