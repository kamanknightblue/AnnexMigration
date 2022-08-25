using AnnexMigration.EntityFrameworkCore;
using AnnexMigration.FUpfiles;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AnnexMigration.SNKModel
{
    [ConnectionStringName(AnnexMigrationDbProperties.HSBDCBZB2022ConnectionStringName)]
    public class HSBDCBZB2022Context : AbpDbContext<HSBDCBZB2022Context>
    {
        public HSBDCBZB2022Context(DbContextOptions<HSBDCBZB2022Context> options)
            : base(options)
        {

        }

        public DbSet<FUpfile> FUpfiles { get; set; }
        public DbSet<FCasematerial> FCasematerials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FUpfile>(b =>
            {
                b.ToTable("F_UPFILEs", schema: null);
                b.HasKey(nameof(FUpfile.Id));
                b.ConfigureByConvention();
            });

            modelBuilder.Entity<FCasematerial>(b =>
            {
                b.ToTable("F_CASEMATERIAL", schema: null);
                b.HasKey(nameof(FCasematerial.Id));
                b.ConfigureByConvention();
            });
        }
    }
}
