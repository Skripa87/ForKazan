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

        public BusRoute(string numberBusRoute, List<CurrentBusPoint> currentBusPoints)
        {
            BusStops = new List<BusStop>();
            NumberBusRoute = numberBusRoute;
            IntermediatePointsForBuilding = InitPointsForBuilding(currentBusPoints).ToList();
        }

        private IEnumerable<IntermediatePointsForBuilding> InitPointsForBuilding(List<CurrentBusPoint> currentBusPoints)
        {
            return currentBusPoints.Select(a => new Models.IntermediatePointsForBuilding(a.TimeNav, a.GaragNumb, a.Graph, a.Smena, a.Azimuth, a.Latitude, a.Longitude, a.Speed));
        }

        public void InsertBusRoute(BusRoute busRoute)
        {
            if (!this.NumberBusRoute.Equals(busRoute.NumberBusRoute)) return;
            IntermediatePointsForBuilding.AddRange(busRoute.IntermediatePointsForBuilding);
        }
    }
}