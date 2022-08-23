using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnnexMigration.SNKModel
{
    public partial class HSBDCBZB2022Context : DbContext
    {
        public HSBDCBZB2022Context()
        {
        }

        public HSBDCBZB2022Context(DbContextOptions<HSBDCBZB2022Context> options)
            : base(options)
        {
        }
        public virtual DbSet<FUpfile> FUpfiles { get; set; }
        public virtual DbSet<FCasematerial> FCasematerials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FUpfile>(entity =>
            {
                entity.ToTable("F_UPFILES");

                entity.HasIndex(e => e.Caseno, "IX_F_UPFILES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caseno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Downloadstatu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DOWNLOADSTATU");

                entity.Property(e => e.Filecontent)
                    .HasColumnType("image")
                    .HasColumnName("FILECONTENT");

                entity.Property(e => e.Fileid)
                    .HasMaxLength(50)
                    .HasColumnName("FILEID");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FILENAME");

                entity.Property(e => e.Fileno).HasColumnName("FILENO");

                entity.Property(e => e.Filepath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FILEPATH");

                entity.Property(e => e.Filesize)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILESIZE");

                entity.Property(e => e.Ftpkeyname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FTPKEYNAME");

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Materialname)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MATERIALNAME");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Upfiletime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPFILETIME");

                entity.Property(e => e.Uptype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPTYPE");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.入库批次)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.预编宗地代码)
                    .HasMaxLength(19)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FCasematerial>(entity =>
            {
                entity.ToTable("F_CASEMATERIAL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AID");

                entity.Property(e => e.Caseno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.Casetitle)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CASETITLE");

                entity.Property(e => e.Copies)
                    .HasColumnName("COPIES")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Filesource).HasColumnName("FILESOURCE");

                entity.Property(e => e.Materialid).HasColumnName("MATERIALID");

                entity.Property(e => e.Materialname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MATERIALNAME");

                entity.Property(e => e.Must).HasColumnName("MUST");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Original).HasColumnName("ORIGINAL");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Sign).HasColumnName("SIGN");

                entity.Property(e => e.Subtype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUBTYPE");

                entity.Property(e => e.Tiid).HasColumnName("TIID");

                entity.Property(e => e.入库批次)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.预编宗地代码)
                    .HasMaxLength(19)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
