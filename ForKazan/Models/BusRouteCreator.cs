using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class BusRouteCreator
    {
        private string CreateFileNameOfDateTime(DateTime dateTime)
        {
            string fileName = "Otmetki_";
            fileName += dateTime.Year.ToString() + "_" 
                     + (dateTime.Month
                                .ToString()
                                .Length == 1 
                       ? "0" + dateTime.Month.ToString()
                       : dateTime.Month.ToString()) + "_" 
                     + (dateTime.Day
                                .ToString()
                                .Length == 1
                       ? "0" + dateTime.Day
                                       .ToString()
                       : dateTime.Day
                                 .ToString()) + "_" 
                     + (dateTime.Hour
                                .ToString()
                                .Length == 1 
                       ? "0" + dateTime.Hour
                                       .ToString()
                       : dateTime.Hour
                                       .ToString()) + "_" 
                     + (dateTime.Minute
                                .ToString()
                                .Length == 1 
                        ? "0" + dateTime.Minute
                                        .ToString()
                        : dateTime.Minute.ToString()) + ".xml";
            return fileName;
        }

        public List<BusRoute> CreateBusRoutes()
        {
            var ftpDataReader = new FtpDataReader("ftp://192.168.10.10:21//bus1", "ftpuser", "Ln8#{T7nRsmd"); 
            var busRoutes = new List<BusRoute>();
            var InputDate = DateTime.Now.AddDays(-1);
            InputDate = InputDate.AddHours(-1 * InputDate.Hour)
                                 .AddMinutes(-1 * InputDate.Minute)
                                 .AddSeconds(-1 * InputDate.Second);
            while (!InputDate.Day.Equals(DateTime.Now.Day))
            {
                string fileName = CreateFileNameOfDateTime(InputDate);
                var data = ftpDataReader.GetFtpNativeBusesPoint(fileName).BusPositionsPoints;
                var busRoute = new BusRoute("",data);
                InputDate = InputDate.AddMinutes(1);
            }
            return busRoutes;
        }
    }
}