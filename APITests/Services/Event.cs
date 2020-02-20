
namespace PortalApp
{
    public class Event : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.cirListVersion;

        //GET calls
        public void GetEvent(string eventId)
        {
            URLi = $"{protocol}://{serverName}/events/api/v{version}/Event/Details/{eventId}";
        }

        public void GetEventByDate(string fromDate = "", string toDate = "")
        {
            URLi = $"{protocol}://{serverName}/events/api/v{version}/Event/List";

            if ((fromDate == "") && (toDate == ""))
                return;

            if (fromDate != "")
                URLi = URLi + $"?from={fromDate}";

            if (toDate != "" && fromDate != "")
                URLi = URLi + $"&to={toDate}";
            else
                URLi = URLi + $"?to={toDate}";

        }

    }
}