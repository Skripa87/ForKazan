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
                ws.Cell(1, 1).SetValue("Время");
                ws.Cell(1, 2).SetValue("Номер машины");
                ws.Cell(1, 3).SetValue("График");
                ws.Cell(1, 4).SetValue("Смена");
                ws.Cell(1, 5).SetValue("Азимут");
                ws.Cell(1, 6).SetValue("Широта");
                ws.Cell(1, 7).SetValue("Долгота");
                ws.Cell(1, 8).SetValue("Скорость");
                var row = 2;
                var k = 0;
                var goden = 0;
                foreach (var item in busRoute.IntermediatePointsForBuilding)
                {
                    if (goden != 10) { goden++; continue; }
                    else { goden = 0; }
                    ws.Cell(row, 1).SetValue(item.TimePoint);
                    ws.Cell(row, 2).SetValue(item.GarageNumber);
                    ws.Cell(row, 3).SetValue(item.Graphic);
                    ws.Cell(row, 4).SetValue(item.Smena);
                    ws.Cell(row, 5).SetValue(item.Azimut);
                    ws.Cell(row, 6).SetValue(item.Latitude);
                    ws.Cell(row, 7).SetValue(item.Longitude);
                    ws.Cell(row, 8).SetValue(item.Speed);
                    row++;
                    if (row > 64000)
                    {
                        k++;
                        ws = workbook.Worksheets.Add(busRoute.NumberBusRoute + "_" + k);
                        ws.Cell(1, 1).SetValue("Время");
                        ws.Cell(1, 2).SetValue("Номер машины");
                        ws.Cell(1, 3).SetValue("График");
                        ws.Cell(1, 4).SetValue("Смена");
                        ws.Cell(1, 5).SetValue("Азимут");
                        ws.Cell(1, 6).SetValue("Широта");
                        ws.Cell(1, 7).SetValue("Долгота");
                        ws.Cell(1, 8).SetValue("Скорость");
                        row = 2;
                    }                    
                }
                ws.Columns().AdjustToContents();
            }
            workbook.SaveAs(FileName);            
        }
    }
}