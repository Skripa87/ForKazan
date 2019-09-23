using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForKazan.Models
{
    public class NavigationDataOnPeriod
    {
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public List<BusPositionPoint> BusPositionsPoints { get; set; }
        public int  SampleSize { get; set; }

        public NavigationDataOnPeriod()
        {
            StartPeriod = DateTime.MinValue;
            EndPeriod = DateTime.MaxValue;
            BusPositionsPoints = new List<BusPositionPoint>();
            SampleSize = 0;
        }
    }
}