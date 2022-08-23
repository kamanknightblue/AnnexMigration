using AnnexMigration.Annexes;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace AnnexMigration.MongoDB;

public static class AnnexMigrationMongoDbContextExtensions
{
    public static void ConfigureAnnexMigration(this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Annex>(b =>
        {
            b.CollectionName = "Annexex";
        });
    }
}
