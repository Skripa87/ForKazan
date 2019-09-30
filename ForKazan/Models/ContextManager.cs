using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class ContextManager
    {
        private ForKazanDbContext Db { get; set; }
        
        public ContextManager()
        {
            Db = new ForKazanDbContext();
        }

        public List<BusStop> GetBusStops()
        {
            return Db.BusStops.ToList();
        }

    }
}