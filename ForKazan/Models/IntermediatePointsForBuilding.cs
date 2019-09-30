using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class IntermediatePointsForBuilding
    {
        public DateTime TimePoint { get; set; }
        public int GarageNumber { get; set; }
        public int Graphic { get; set; }
        public int Smena { get; set; }
        public int Azimut { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }

        public IntermediatePointsForBuilding(string timePoint, string garagnumber, string graphic, string smena, string azimuth, string latitude, string longitude, string speed)
        {
            TimePoint = DateTime.TryParse(timePoint, out var time)
                      ? time
                      : DateTime.MinValue;
            GarageNumber = int.TryParse(garagnumber, out int garagNumber)
                         ? garagNumber
                         : -1;
            Graphic = int.TryParse(graphic, out int graphicNumber)
                    ? graphicNumber
                    : -1;
            Smena = int.TryParse(smena, out var smenaNum)
                  ? smenaNum
                  : -1;
            Azimut = int.TryParse(azimuth, out var azimuthNum)
                     ? azimuthNum
                     : -1;
            Latitude = double.TryParse(latitude, out var latnumber)
                     ? latnumber
                     : (double.TryParse(latitude.Replace(',','.'),out var latnumberIfNotPoint) 
                       ? latnumberIfNotPoint
                       : -1);
            Longitude = double.TryParse(longitude, out var longnumber)
                      ? longnumber
                      : (double.TryParse(longitude.Replace(',','.'), out var longnumberIfNotPoint) 
                        ? longnumberIfNotPoint
                        : -1);
            Speed = double.TryParse(speed, out var spd)
                  ? spd
                  : -1;
        }
    }
}