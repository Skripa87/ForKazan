using System;

namespace ForKazan.Models
{
    public static class Matematic
    {
        public static double GaversinusMethod(double latitudeA, double latitudeB, double longitudeA, double longitudeB)
        {
            double result;
            var sqadCosSin = Math.Pow(Math.Cos(latitudeB) * Math.Sin(longitudeB - longitudeA), 2);
            var cosSinLat = Math.Cos(latitudeA) * Math.Sin(latitudeB);
            var sinCosCos = Math.Sin(latitudeA) * Math.Cos(latitudeB) * Math.Cos(longitudeB - longitudeA);
            var sqadSinCosCos = Math.Pow(cosSinLat - sinCosCos, 2);
            return result = 6372795 * Math.Atan(Math.Pow(sqadCosSin + sqadSinCosCos, 0.5) / (Math.Sin(latitudeA) * Math.Sin(latitudeB) + Math.Cos(latitudeA) * Math.Cos(latitudeB) * Math.Cos(longitudeB - longitudeA)));
        }

        public static double DistanceBetweenPointsInSpace(
                double X1, double Y1, double Z1,
                double X2, double Y2, double Z2
        ) => Math.Sqrt(
            Math.Pow(X2 - X1, 2) +
            Math.Pow(Y2 - Y1, 2) +
            Math.Pow(Z2 - Z1, 2)
        );
    }
}