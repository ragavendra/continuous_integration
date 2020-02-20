
namespace PortalApp
{
    public class EOT : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;

        public void BusStatuses(string routeFilter = "")
        {
            if (routeFilter != "")
                URLi = $"{protocol}://{serverName}/busstatus/api/BusStatuses?routeFilter={routeFilter}";
            else
                URLi = $"{protocol}://{serverName}/busstatus/api/BusStatuses";
        }

        public void BusStatusesHistory(string dateTime)
        {
            URLi = $"{protocol}://{serverName}/busstatus/api/BusStatuses/History/{dateTime}";
        }

        public void BusStatusesTimeLapse(string fromDateTime, string toDateTime, string intervalInSeconds)
        {
            URLi = $"{protocol}://{serverName}/busstatus/api/BusStatuses/timelapse/{fromDateTime}/{toDateTime}/{intervalInSeconds}";
        }

        public void Status(string requestId = "")
        {
            URLi = $"{protocol}://{serverName}/busstatus/api/Status?requestId={requestId}";
        }


        public void GetScheduleAndBuses(string stopNo, string count, string timeFrame)
        {
        }

    }
}