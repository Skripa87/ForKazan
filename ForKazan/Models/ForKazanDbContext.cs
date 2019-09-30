using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class ForKazanDbContext : DbContext
    {
        public ForKazanDbContext() : base ("Name = ForKazanDataBase") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
    }
}