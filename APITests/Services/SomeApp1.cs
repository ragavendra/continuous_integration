
namespace AppName
{
    public class SomeApp1 : Rest
    {
        
        private string serverName = Constants.eotServerName;
        private const string protocol = Constants.protocol;

        public void SomeApp1_(string routeFilter = "")
        {
            if (routeFilter != "")
                URLi = $"{protocol}://{serverName}/someapp1/api/SomeApp1?routeFilter={routeFilter}";
            else
                URLi = $"{protocol}://{serverName}/someapp1/api/SomeApp1";
        }

        public void SomeApp1History(string dateTime)
        {
            URLi = $"{protocol}://{serverName}/someapp1/api/SomeApp1/History/{dateTime}";
        }

        public void SomeApp1TimeLapse(string fromDateTime, string toDateTime, string intervalInSeconds)
        {
            URLi = $"{protocol}://{serverName}/someapp1/api/SomeApp1/timelapse/{fromDateTime}/{toDateTime}/{intervalInSeconds}";
        }

        public void Status(string requestId = "")
        {
            URLi = $"{protocol}://{serverName}/someapp1/api/Status?requestId={requestId}";
        }


        public void GetScheduleAndBuses(string stopNo, string count, string timeFrame)
        {
        }

    }
}