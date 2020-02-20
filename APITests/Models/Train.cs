using System;

namespace PortalApp.Models
{
    public class Train
    {
        public int train { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }
        public int vehicle1 { get; set; }
        public int vehicle2 { get; set; }
        public int vehicle3 { get; set; }
        public int previousTrackSection { get; set; }
        public int trackSection { get; set; }
        public DateTime lastPositionUpdateTS { get; set; }
        public int lineRoute { get; set; }
        public string lineDesc { get; set; }
        public double route { get; set; }
        public int direction { get; set; }
        public double exit { get; set; }
        public double atcStation { get; set; }
        public string atcStationName { get; set; }
        public double run { get; set; }
        public string runDesc { get; set; }
        public string previousFaultLow { get; set; }
        public string currentFaultLow { get; set; }
        public string previousFaultHigh { get; set; }
        public string currentFaultHigh { get; set; }
        public double mode { get; set; }
        public double lastTrain { get; set; }
        public bool isManual { get; set; }
        public bool isActive { get; set; }
        public bool fc1 { get; set; }
        public bool fc2 { get; set; }
        public bool fc3 { get; set; }
        public bool fc4 { get; set; }
        public bool fc5 { get; set; }
        public bool fc6 { get; set; }
        public bool fc7 { get; set; }
        public bool fc8 { get; set; }
        public bool fc9 { get; set; }
        public bool fc10 { get; set; }
        public bool fc11 { get; set; }
        public bool fc12 { get; set; }
        public bool fc13 { get; set; }
        public bool fc14 { get; set; }
        public bool fc15 { get; set; }
        public bool fc99 { get; set; }
        public string zone1 { get; set; }
        public string zone2 { get; set; }
        public string zone3 { get; set; }
        public string station { get; set; }
        public double stationChainage { get; set; }
        public string currentDateUpdated { get; set; }
        public string currentTimeUpdated { get; set; }
        public double partOfTrain { get; set; }
        public string consistChainOfTrain { get; set; }
        public string nextStationName { get; set; }
        public double nextStationNumber { get; set; }
        public double terminusStationNumber { get; set; }
        public string terminusStationName { get; set; }
        public double doorStatus { get; set; }
        public double routeLine { get; set; }
        public string exitName { get; set; }
        public string faultCodes { get; set; }
    }
}