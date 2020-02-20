using System;

namespace PortalApp
{
    public class TrainStationStatus : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void GetTrainsStationStatuses()
        {
            URLi = $"{protocol}://{serverName}/trainstationstatus/api/StationStatuses";
        }

        public void GetTrainStationStatus(string id = "")
        {
            if (id == "")
                URLi = $"{protocol}://{serverName}/trainstationstatus/api/Status";
            else
                URLi = $"{protocol}://{serverName}/trainstationstatus/api/Status?requestId={id}";
        }

        //2019-11-07T15:00:00Z
        public void GetTrainStatusHistory(DateTime dateTime)
        {
            URLi = $"{protocol}://{serverName}/trainstatus/api/TrainStatuses/History/{dateTime.ToString("yyyy-MM-ddTHH:mm:ss")}";
        }

        public void GetTrainStatusTimelapse(DateTime fromDateTime, DateTime toDateTime, int intervalInSeconds)
        {
            URLi = $"{protocol}://{serverName}/trainstatus/api/TrainStatuses/timelapse/{fromDateTime.ToString("yyyy-MM-ddTHH:mm:ss")}/{toDateTime.ToString("yyyy-MM-ddTHH:mm:ss")}/{intervalInSeconds.ToString()}";
        }

    }
}
