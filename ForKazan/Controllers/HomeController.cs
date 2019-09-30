using ForKazan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;

namespace ForKazan.Controllers
{  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ftpR = new FtpDataReader("ftp://192.168.10.10//bus1","ftpuser", "Ln8#{T7nRsmd");
            var busRoutes = ftpR.CreateBusRoutes();
            var worker = new XLWorker("D:\\table.xlsx");
            worker.CreateXLDocument(busRoutes);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}