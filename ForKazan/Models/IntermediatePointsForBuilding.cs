using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class IntermediatePointsForBuilding
    {
        public DateTime TimePoint { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }

        public IntermediatePointsForBuilding(string timePoint, string latitude, string longitude, string speed)
        {
            TimePoint = DateTime.TryParse(timePoint, out var time)
                      ? time
                      : DateTime.MinValue;
            Latitude = double.TryParse(latitude, out var latnumber)
                     ? latnumber
                     : -1;
            Longitude = double.TryParse(longitude, out var longnumber)
                      ? longnumber
                      : -1;
            Speed = double.TryParse(speed, out var spd)
                  ? spd
                  : -1;
        }
    }
}