using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public static class Matematic
    {
        //private double Epsilun { get; set; }

        //private int Level { get; set; }

        //private List<List<double>> CreateMatrixA(List<double> listX)
        //{
        //    var matrixA = new List<List<double>>();
        //    for (int i = 0; i < Level; i++)
        //    {
        //        var buff = new List<double>();
        //        for (int j = 0; j < Level; j++)
        //        {
        //            buff.Add(0);
        //        }
        //        matrixA.Add(buff);
        //    }
        //    for (int i = 0; i < Level; i++)
        //        for (int j = 0; j < Level; j++)
        //        {
        //            if (i == 0 && j == 0)
        //            {
        //                matrixA[i][j] = listX.Count + 1;
        //            }
        //            else if (i == 0)
        //            {
        //                matrixA[i][j] = listX.Sum(x => Math.Pow(x, j + i));
        //            }
        //            if (i > 0 && j < Level - i)
        //            {
        //                matrixA[i][j] = matrixA[i - 1][j + 1];
        //            }
        //            else
        //            {
        //                matrixA[i][j] = listX.Sum(x => Math.Pow(x, j + i));
        //            }
        //        }
        //    return matrixA;
        //}

        //private List<double> IntegrateListsElement(List<double> listA, List<double> listB, double power)
        //{
        //    var result = new List<double>();
        //    foreach (var item in listA)
        //    {
        //        result.Add(item * Math.Pow(listB.ElementAt(listA.IndexOf(item)), power));
        //    }
        //    return result;
        //}

        //private List<double> CreateListB(List<double> listX, List<double> listY)
        //{
        //    var listB = new List<double>();
        //    for (int i = 0; i < Level; i++)
        //    {
        //        listB.Add(IntegrateListsElement(listY, listX, i).Sum());
        //    }
        //    return listB;
        //}

        //private List<double> InitFindingElements()
        //{
        //    var result = new List<double>();
        //    for (int i = 0; i < Level; i++)
        //    {
        //        result.Add(0);
        //    }
        //    return result;
        //}

        //private List<double> GausZeidelMethod(List<List<double>> matrix, List<double> list)
        //{
        //    double[] resultX = new double[Level];
        //    var prevX = InitFindingElements();
        //    do
        //    {
        //        for (int i = 0; i < Level; i++)
        //        {
        //            double sum = 0;
        //            foreach (var item in prevX)
        //            {
        //                if (prevX.IndexOf(item) == i) continue;
        //                sum += matrix[i][prevX.IndexOf(item)] * item;
        //            }
        //            resultX[i] = (1 / matrix[i][i]) * (list[i]) - sum;
        //        }
        //        var checkArray = new List<double>();
        //        for (int i = 0; i < Level; i++)
        //        {
        //            checkArray.Add(resultX[i] - prevX.ElementAt(i));
        //        }
        //        if (checkArray.Sum() < Epsilun) break;
        //        for (int i = 0; i < Level; i++)
        //        {
        //            prevX[i] = resultX[i];
        //        }
        //    } while (true);
        //    return resultX.ToList();
        //}

        //public Dictionary<string, List<double>> GetKeys(List<BusRoute> busRoutes)
        //{
        //    var result = new Dictionary<string, List<double>>();
        //    foreach (BusRoute busRoute in busRoutes)
        //    {
        //        var numberBusRoute = busRoute.NumberBusRoute;
        //        var findingX = new List<double>();
        //        var listX = busRoute.IntermediatePoints
        //                            .Select(s => s.Latitude)
        //                            .ToList();
        //        var listY = busRoute.IntermediatePoints
        //                            .Select(s => s.Longitude)
        //                            .ToList();
        //        var matrixA = CreateMatrixA(listX);
        //        var listB = CreateListB(listX, listY);

        //    }
        //    return result;
        //}

        //public Matematic(double epsilun, int level)
        //{
        //    Epsilun = epsilun;
        //    Level = level;
        //}
    }
}