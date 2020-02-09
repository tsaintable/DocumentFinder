namespace DocumentFinder.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<DOCUMENT> DOCUMENTs { get; set; }
        public virtual DbSet<DOCUMENT_CONTENT> DOCUMENT_CONTENT { get; set; }
        public virtual DbSet<DOCUMENT_DISTRIBUTION> DOCUMENT_DISTRIBUTION { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocType)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocName)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocManuf)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocCatg)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocWONum)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocPONum)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocProjMgr)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocEqpAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOCUMENT>()
                .Property(e => e.DocDescr)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT_CONTENT>()
                .Property(e => e.UniqueContentID)
                .IsFixedLength();

            modelBuilder.Entity<DOCUMENT_CONTENT>()
                .Property(e => e.ContentNumber)
                .IsFixedLength();

            modelBuilder.Entity<DOCUMENT_CONTENT>()
                .Property(e => e.ContentDescription)
                .IsFixedLength();

            modelBuilder.Entity<DOCUMENT_CONTENT>()
                .Property(e => e.ContentVersion)
                .IsFixedLength();

            modelBuilder.Entity<DOCUMENT_CONTENT>()
                .Property(e => e.ContentDateAssigned)
                .IsFixedLength();

            modelBuilder.Entity<DOCUMENT_DISTRIBUTION>()
                .Property(e => e.DistributionOwner)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT_DISTRIBUTION>()
                .Property(e => e.DistributionLocation)
                .IsUnicode(false);

            modelBuilder.Entity<DOCUMENT_DISTRIBUTION>()
                .Property(e => e.DistributionAmount)
                .HasPrecision(19, 4);
        }
    }
}
