using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ForKazan.Models
{
    public class FtpDataReader
    {
        public string FtpPath { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        private string ReadFileToString(string fileName)
        {
            string result = "";
            var request = new WebClient();
            string url = FtpPath + fileName;
            request.Credentials = new NetworkCredential(UserName, Password);

            try
            {
                byte[] newFileData = request.DownloadData(url);
                result = System.Text.Encoding.UTF8.GetString(newFileData);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public NavigationDataOnPeriod GetFtpNativeBusesPoint(string fileName)
        {
            var reader = new StringReader(ReadFileToString(fileName));
            XmlDocument Document = new XmlDocument();
            Document.Load(reader);
            var navigationDataOnPeriod = new NavigationDataOnPeriod();
            try
            {
                var items = Document.GetElementsByTagName("item");
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        var attributes = ((XmlNode)item).Attributes;
                        string garageNum = "", marsh = "", graph = "", smena = "", timenav = "", latitude = "", longitude = "", speed = "", azimuth = "";
                        foreach (XmlAttribute attr in attributes)
                        {
                            switch(attr.Name)
                            {
                                case "GaragNumb":garageNum = attr.Value; break;
                                case "Marsh":marsh = attr.Value; break;
                                case "Graph":graph = attr.Value; break;
                                case "Smena":smena = attr.Value; break;
                                case "TimeNav":timenav = attr.Value; break;
                                case "Latitude":latitude = attr.Value; break;
                                case "Longitude":longitude = attr.Value; break;
                                case "Speed":speed = attr.Value; break;
                                case "Azimuth":azimuth = attr.Value; break;
                            }
                        }
                        navigationDataOnPeriod.BusPositionsPoints.Add(new BusPositionPoint(garageNum, marsh, graph, smena, timenav, latitude, longitude, speed, azimuth));                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            try
            {
                var start = Document.GetElementsByTagName("time")[0];
                string startperiod = "", endperiod = "";
                foreach (XmlAttribute attr in ((XmlNode)start).Attributes)
                {
                    switch (attr.Name)
                    {
                        case "ot": startperiod = attr.Value; break;
                        case "do": endperiod = attr.Value; break;                        
                    }
                }
                if (DateTime.TryParse(startperiod, out var startPeriod))
                    navigationDataOnPeriod.StartPeriod = startPeriod;
                if (DateTime.TryParse(endperiod, out var endPeriod))
                    navigationDataOnPeriod.EndPeriod = endPeriod;
            }
            catch (Exception ex)
            {
                return null;
            }
            try
            {
                var samplesize = ((XmlAttribute)(((XmlNode)Document.GetElementsByTagName("Stat")[0]).Attributes[0])).Value;
                if (int.TryParse(samplesize, out int count))
                    navigationDataOnPeriod.SampleSize = count;
            }
            catch (Exception ex)
            {
                return null;
            }
            return navigationDataOnPeriod;
        }

        public FtpDataReader(string ftpPath, string user, string password)
        {
            FtpPath = ftpPath;
            UserName = user;
            Password = password;
        }
    }
}