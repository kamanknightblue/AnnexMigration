namespace AnnexMigration;

public static class AnnexMigrationDbProperties
{
    public static string DbTablePrefix { get; set; } = "AnnexMigration";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AnnexMigration";
    public const string MongoDbConnectionStringName = "AnnexMigrationMongo";
    public const string HSBDCBZB2022ConnectionStringName = "HSBDCBZB2022";
    public const string WorkflowConnectionStringName = "Workflow";
}
