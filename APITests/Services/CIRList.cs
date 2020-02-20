
namespace PortalApp
{
    public class CIRList : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.cirListVersion;

        //GET calls
        public void GetCIR(string cirId)
        {
            URLi = $"{protocol}://{serverName}/cirlist/api/v{version}/CirList/cirs/{cirId}";
        }

        public void searchCir(string fromDate = "", string toDate = "", string searchCriteria = "")
        {
            URLi = $"{protocol}://{serverName}/cirlist/api/v{version}/CirList/cirs?";

            //"ss=abc&sk=xyz&fd=123&td=235&ui=jjj"
            if ((fromDate == "") && (toDate == "") && (searchCriteria == ""))
                return;

            if (fromDate != "")
                URLi = URLi + $"&fromDate={fromDate}";

            if (toDate != "")
                URLi = URLi + $"&toDate={toDate}";

            if (searchCriteria != "")
                URLi = URLi + $"&searchCriteria={searchCriteria}";

        }

    }
}