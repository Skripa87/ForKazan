using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class MapPoint
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Azimut { get; set; }

        public MapPoint(string longitude, string latitude, string azimuth)
        {

        }
    }
}