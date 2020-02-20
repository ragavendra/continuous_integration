using System;
using System.Collections.Generic;

namespace PortalApp.Models
{
    public class TrainStation
    {

        public int platformID { get; set; }
        public string platformShortName { get; set; }
        public string platformName { get; set; }
        public DateTime predictionTime { get; set; }
        public int sequence { get; set; }
        public string train { get; set; }
        public DateTime arrival { get; set; }
        public DateTime departure { get; set; }
        public bool stop { get; set; }
        public bool exit { get; set; }
        public int line { get; set; }
        public int terminusPlatformID { get; set; }
        public string terminusPlatformShortName { get; set; }
        public string terminusPlatformName { get; set; }
        public bool passenger { get; set; }

    }

    public class TrainStationResponse_
    {
        public List<TrainStation> response { get; set; }
    }

    public class Response
    {
        public int platformID { get; set; }
        public string platformShortName { get; set; }
        public string platformName { get; set; }
        public DateTime predictionTime { get; set; }
        public int sequence { get; set; }
        public string train { get; set; }
        public DateTime arrival { get; set; }
        public DateTime departure { get; set; }
        public bool stop { get; set; }
        public bool exit { get; set; }
        public int line { get; set; }
        public int? terminusPlatformID { get; set; }
        public string terminusPlatformShortName { get; set; }
        public string terminusPlatformName { get; set; }
        public bool passenger { get; set; }
    }

    public class TrainStationResponse
    {
        public List<Response> response { get; set; }
        public object error { get; set; }
        public string requestId { get; set; }
        public int statusCode { get; set; }
    }

}