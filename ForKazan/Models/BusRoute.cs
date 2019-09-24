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
        public List<IntermediatePointsForBuilding> IntermediatePointsForBuilding { get; set; }

        public BusRoute(string numberBusRoute, List<BusPositionPoint> busPositionPoints)
        {
            BusStops = new List<BusStop>();
            NumberBusRoute = numberBusRoute;
            IntermediatePointsForBuilding = InitPointsForBuilding(busPositionPoints).ToList();
        }

        private IEnumerable<IntermediatePointsForBuilding> InitPointsForBuilding(List<BusPositionPoint> busPositionPoints)
        {
            return busPositionPoints.Select(a => new Models.IntermediatePointsForBuilding(a.TimeNav, a.Latitude, a.Longitude, a.Speed));
        }


    }
}