using System;
using System.Collections.Generic;

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

        public List<double> TranslateToOrthogonalProjection(double H = 125)
        {
            double a = 63781370.0, b = 6356752.3142, ePow = 0.00669437999014,
                X, Y, Z;

            double nB = a / Math.Sqrt(1 - ePow - Math.Pow(Math.Sin(Latitude), 2));

            X = (nB + H) * Math.Cos(Latitude) * Math.Cos(Longitude);
            Y = (nB + H) * Math.Cos(Latitude) * Math.Sin(Longitude);
            Z = ((Math.Pow(b, 2) / Math.Pow(a, 2)) * nB + H) * Math.Sin(Latitude);

            return new List<double> { X, Y, Z };
        }
    }
}