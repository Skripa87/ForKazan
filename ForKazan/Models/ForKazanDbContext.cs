using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public partial class ForKazanDbContext : DbContext
    {
        public ForKazanDbContext()
            : base("name=ForKazanDataBaseB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BusRoute> BusRoutes { get; set; }
        public virtual DbSet<BusStop> BusStops { get; set; }
        public virtual DbSet<IntermediatePoint> IntermediatePoints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusRoute>()
                .HasMany(e => e.IntermediatePoints)
                .WithOptional(e => e.BusRoute)
                .HasForeignKey(e => e.BusRoute_Id);

            modelBuilder.Entity<BusRoute>()
                .HasMany(e => e.BusStops)
                .WithMany(e => e.BusRoutes)
                .Map(m => m.ToTable("BusStopBusRoutes"));
        }
    }
}