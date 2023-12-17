using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RKISControl.Data
{
    public partial class RentMallDataContext : DbContext
    {
        public RentMallDataContext()
            : base("name=DataModelEF")
        {
        }

        public virtual DbSet<Mall> Malls { get; set; }
        public virtual DbSet<Pavilion> Pavilions { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mall>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mall>()
                .HasMany(e => e.Pavilions)
                .WithRequired(e => e.Mall)
                .HasForeignKey(e => e.ID_mall)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mall>()
                .HasMany(e => e.Rents)
                .WithOptional(e => e.Mall)
                .HasForeignKey(e => e.ID_Mall);

            modelBuilder.Entity<Pavilion>()
                .HasMany(e => e.Rents)
                .WithOptional(e => e.Pavilion)
                .HasForeignKey(e => new { e.Num_pav, e.ID_Mall });

            modelBuilder.Entity<Tenant>()
                .HasMany(e => e.Rents)
                .WithOptional(e => e.Tenant)
                .HasForeignKey(e => e.ID_tenan);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Rents)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.ID_workers);
        }
    }
}
