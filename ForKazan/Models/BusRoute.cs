using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class BusRoute
    {
        public string NumberBusRoute { get; set; }        
        public List<BusStop> BusStops {get;set;}        
        public List<IntermediatePointsForBuilding> IntermediatePointsForBuildings { get; set; }

        public BusRoute()
        {
            BusStops = new List<BusStop>();
            IntermediatePointsForBuildings = new List<IntermediatePointsForBuilding>();
        }
    }
}