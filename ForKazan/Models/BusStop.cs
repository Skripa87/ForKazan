using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class BusStop
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual List<BusRoute> BusRoutes { get; set; }
        public BusStop()
        {
            BusRoutes = new List<BusRoute>();
        }
    }
}