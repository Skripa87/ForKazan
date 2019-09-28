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
                for (int i = 0; i < 5; i++)
                {
                    var buff = new List<double>();
                    for (int j = 0; j < 5; j++)
                    {
                        buff.Add(0);
                    }
                    matrixA.Add(buff);
                }
                var listB = new List<double>();
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            matrixA[i][j] = countX + 1;
                        }
                        else if (i == 0)
                        {
                            matrixA[i][j] = listX.Sum(x => Math.Pow(x, j + i));
                        }
                        if (i > 0 && j < 5 - i)
                        {
                            matrixA[i][j] = matrixA[i - 1][j + 1];
                        }
                        else
                        {
                            matrixA[i][j] = listX.Sum(x => Math.Pow(x, j + i));
                        }
                    }
                foreach (var item in listY)
                {

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