using System;
using System.Collections.Generic;

namespace PortalApp.Models
{

    public class Sheet
    {
        public string Desc { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string id { get; set; }
        public string docType { get; set; }
    }

    public class RouteMap
    {
        public Sheet Sheet { get; set; }
        public string LineNo { get; set; }
        public string ServiceType { get; set; }
        public string Desc { get; set; }
        public string SubRegion { get; set; }
        public object DepotTags { get; set; }
        public string BusCategoryTags { get; set; }
        public string RouteMapFileName { get; set; }
        public string RouteDescriptionFileName { get; set; }
        public string id { get; set; }
    }

    public class Paddles
    {
        public Sheet sheet { get; set; }
        public string lineNo { get; set; }
        public string serviceType { get; set; }
        public string desc { get; set; }
        public string subRegion { get; set; }
        public string depotTags { get; set; }
        public string busCategoryTags { get; set; }
        public string paddleFileName { get; set; }
        public string blockReportFileName { get; set; }
        public string id { get; set; }
        public string docType { get; set; }
    }

}