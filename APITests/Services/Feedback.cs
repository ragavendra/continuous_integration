
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{
    public class Feedback : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.cirListVersion;

        //GET calls
        public void GetFeedback(string feedbackId)
        {
            URLi = $"{protocol}://{serverName}/feedback/v{version}/feedback/{feedbackId}";
        }

        public void GetFeedback(string featureId = "", string fd = "", string td = "", string pn = "", string ps = "")
        {
            int iIndex = 0;
            URLi = "";

            if ((fd == "") && (td == "") && (pn == "") && (ps == ""))
            {
                URLi = $"{protocol}://{serverName}/feedback/v{version}/feedback/list/00000000-0000-0000-0000-000000000000";
                return;
            }

            if (fd != "")
            {

                URLi = URLi + $"fromDate={fd}";
                iIndex++;
            }

            if (td != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"toDate={td}";
                iIndex++;
            }

            //page number
            if (pn != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"page={pn}";
                iIndex++;
            }

            //page size
            if (ps != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"pageSize={ps}";
                iIndex++;
            }

            if (featureId == "")
                featureId = "00000000-0000-0000-0000-000000000000";

            URLi = $"{protocol}://{serverName}/feedback/v{version}/feedback/list/{featureId}?" + URLi;

        }


        //POST calls
        public void CreateFeedback(Models.Feedback feedback)
        {
            URLi = $"{protocol}://{serverName}/feedback/v{version}/feedback";
            sMessage = JsonConvert.SerializeObject(feedback);
        }


        //DELETE calls
        public void DeleteFeedback(string feedbackId)
        {
            URLi = $"{protocol}://{serverName}/feedback/v{version}/feedback/{feedbackId}";
        }





    }
}