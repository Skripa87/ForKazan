using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class CurrentBusPoint
    {
        public string GaragNumb { get; set; }
        public string Marsh { get; set; }
        public string Graph { get; set; }
        public string Smena { get; set; }
        public string TimeNav { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Speed { get; set; }
        public string Azimuth { get; set; }

        public CurrentBusPoint(string garagNum, string marsh, string graph, string smena, string timenav, string latitude, string longitude, string speed, string azimuth)
        {
            GaragNumb = garagNum;
            Marsh = marsh;
            Graph = graph;
            Smena = smena;
            TimeNav = timenav;
            Latitude = latitude;
            Longitude = longitude;
            Speed = speed;
            Azimuth = azimuth;
        }
    }
}