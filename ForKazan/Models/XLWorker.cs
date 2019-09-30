using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClosedXML.Excel;

namespace ForKazan.Models
{
    public class XLWorker
    {
        public string FileName { get; set; }

        public XLWorker(string fileName)
        {
            FileName = fileName;
        }

        public void CreateXLDocument(List<BusRoute> busRoutes)
        {
            XLWorkbook workbook = new XLWorkbook();
            foreach (var busRoute in busRoutes)
            {
                //string num = "1";
                var ws = workbook.Worksheets.Add(busRoute.NumberBusRoute);
                ws.Cell(1, 1).SetValue("Азимут");
                ws.Cell(1, 2).SetValue("Широта");
                ws.Cell(1, 3).SetValue("Долгота");
                var row = 2;
                var k = 0;
                var goden = 0;
                foreach (var item in busRoute.IntermediatePoints)
                {
                    ws.Cell(row, 1).SetValue(item.Azimut);
                    ws.Cell(row, 2).SetValue(item.Latitude);
                    ws.Cell(row, 3).SetValue(item.Longitude);                    
                    row++;
                    if (row > 64000)
                    {
                        k++;
                        ws = workbook.Worksheets.Add(busRoute.NumberBusRoute + "_" + k);
                        ws.Cell(1, 1).SetValue("Азимут");
                        ws.Cell(1, 2).SetValue("Широта");
                        ws.Cell(1, 3).SetValue("Долгота");
                        row = 2;
                    }                    
                }
                ws.Columns().AdjustToContents();
            }
            workbook.SaveAs(FileName);            
        }
    }
}