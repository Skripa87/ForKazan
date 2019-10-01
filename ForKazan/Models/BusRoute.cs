using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class BusRoute
    {
        public string Id { get; set; }
        public string NumberBusRoute { get; set; }
        public List<BusStop> BusStops {get;set;}
        public List<IntermediatePoint> IntermediatePoints { get; set; }

        public BusRoute()
        {
            IntermediatePoints = new List<IntermediatePoint>();
            BusStops = new List<BusStop>();
        }

        public BusRoute(string numberBusRoute, List<CurrentBusPoint> currentBusPoints)
        {
            Id = Guid.NewGuid()
                     .ToString();
            BusStops = new List<BusStop>();
            NumberBusRoute = numberBusRoute;
            IntermediatePoints = InitPoints(currentBusPoints).ToList();
        }

        private List<IntermediatePoint> InitPoints(List<CurrentBusPoint> currentBusPoints)
        {
            return SeparateDuplexPoint(currentBusPoints.Select(a => new Models.IntermediatePoint(a.Azimuth, a.Latitude, a.Longitude))
                                                       .ToList());
        }

        private List<IntermediatePoint> SeparateDuplexPoint(List<IntermediatePoint> intermediatePoints)
        {
            int i = 0;
            do
            {
                if (intermediatePoints.Count == 0) break;
                var currentElement = intermediatePoints.ElementAt(i);
                intermediatePoints.RemoveAll(p => Matematic.GaversinusMethod(p.Latitude,currentElement.Latitude,p.Longitude,currentElement.Longitude) <= 1);
                i++;
            } while (i < intermediatePoints.Count);            
            return intermediatePoints;
        }        
        
        public void InsertBusRoute(BusRoute busRoute)
        {
            if (!this.NumberBusRoute.Equals(busRoute.NumberBusRoute)) return;
            IntermediatePoints.AddRange(busRoute.IntermediatePoints);
            SeparateDuplexPoint(IntermediatePoints);
        }

        public void InsertBusStops(List<BusStop> busStops)
        {
            BusStops = busStops.FindAll(b => IntermediatePoints.Any(i => Matematic.GaversinusMethod(i.Latitude,b.Latitude,i.Longitude,b.Longitude)<=1));
        }
    }
}