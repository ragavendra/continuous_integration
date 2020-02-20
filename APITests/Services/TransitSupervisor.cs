
namespace PortalApp
{
    public class TransitSupervisor : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void GetBusCancellationLastUpdate()
        {
            URLi = $"{protocol}://{serverName}/BusCancellationapi/api/BusCancellation/LastUpdate";
        }

        public void GetBusCancellation(string when)
        {
            URLi = $"{protocol}://{serverName}/BusCancellationapi/api/BusCancellation/GetCancellationList/{when.ToLower()}";
        }

        public void FileService(string when)
        {
            URLi = $"{protocol}://{serverName}/BusCancellationapi/api/BusCancellation/GetCancellationList/{when}";
        }



    }
}