
using System;

namespace PortalApp.Models
{
    public class BusCancellations
    {
        public DateTime snapshotTime { get; set; }
        public string snapshotDate { get; set; }
        public string depot { get; set; }
        public string run { get; set; }
        public string line { get; set; }
        public string block { get; set; }
        public object pendingLate { get; set; }
        public string cancellationOrConfirmedLate { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public string category { get; set; }
        public string id { get; set; }

    }

    public class BusStatus_
    {
        public DateTime response { get; set; }
        public object error { get; set; }
        public string requestId { get; set; }
        public int statusCode { get; set; }
    }
}
