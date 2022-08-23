using AnnexMigration.Annexes;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AnnexMigration.MongoDB;

[ConnectionStringName(AnnexMigrationDbProperties.MongoDbConnectionStringName)]
public interface IAnnexMigrationMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
    public IMongoCollection<Annex> Annexex { get; set; }
}