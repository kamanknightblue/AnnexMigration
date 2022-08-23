using AnnexMigration.Annexes;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AnnexMigration.MongoDB;

[ConnectionStringName(AnnexMigrationDbProperties.MongoDbConnectionStringName)]
public class AnnexMigrationMongoDbContext : AbpMongoDbContext, IAnnexMigrationMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Annex> Annexex => Collection<Annex>();

    IMongoCollection<Annex> IAnnexMigrationMongoDbContext.Annexex { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);
        modelBuilder.ConfigureAnnexMigration();
    }
}
