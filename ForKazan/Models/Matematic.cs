using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class Matematic
    {
        private double Epsilun { get; set; }

        public Dictionary<string, List<double>> GauseZeidel(List<BusRoute> busRoutes)
        {
            var result = new Dictionary<string, List<double>>();
            foreach (BusRoute busRoute in busRoutes)
            {
                var numberBusRoute = busRoute.NumberBusRoute;
                var countX = busRoute.IntermediatePointsForBuilding
                                     .Count;
                var listX = busRoute.IntermediatePointsForBuilding
                                    .Select(s => s.Latitude);
                var listY = busRoute.IntermediatePointsForBuilding
                                    .Select(s => s.Longitude);
                var matrixA = new List<List<double>>();
                var listB = new List<double>();
                int i = 0, j = 0;
                for (i = 0; i < 5; i++)
                    for (j = 0; j < 5; j++)
                    {
                        if (i > 0 && j < 4)
                        {
                            matrixA[i][j] = matrixA[i][j + 1];
                        }


            }
                return result;
            }

            public Matematic(double epsilun)
            {
                Epsilun = epsilun;
            }
        }
    }