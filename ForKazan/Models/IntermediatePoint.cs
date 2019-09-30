using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class IntermediatePoint
    {
        public string Id { get; set; }
        public int Azimut { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IntermediatePoint(string azimuth, string latitude, string longitude)
        {
            Id = Guid.NewGuid()
                     .ToString();
            Azimut = int.TryParse(azimuth, out var azimuthNum)
                     ? azimuthNum
                     : -1;
            Latitude = double.TryParse(latitude, out var latnumber)
                     ? latnumber
                     : (double.TryParse(latitude.Replace(',', '.'), out var latnumberIfNotPoint)
                       ? latnumberIfNotPoint
                       : -1);
            Longitude = double.TryParse(longitude, out var longnumber)
                      ? longnumber
                      : (double.TryParse(longitude.Replace(',', '.'), out var longnumberIfNotPoint)
                        ? longnumberIfNotPoint
                        : -1);
        }
    }
}