using System;
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{
    public class IncidentReport : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.incidentReportVersion;

        //GET calls
        public void GetIncidentReport(string reportId)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}";
        }

        public void GetIncidentReportCount(string ss = "", string sk = "", string fd = "", string td = "", string ui = "", string pn = "", string ps = "")
        {
            int iIndex = 0;
            URLi = "";

            //"ss=abc&sk=xyz&fd=123&td=235&ui=jjj"

            if ((ss == "") && (sk == "") && (fd == "") && (td == "") && (ui == ""))
            {
                URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/getCount";
                return;
            }

            if (ss != "")
            {
                URLi = URLi + $"ss={ss}";
                iIndex++;
            }

            if (sk != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"sk={sk}";
                iIndex++;
            }

            if (fd != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"fd={fd}";
                iIndex++;
            }

            if (td != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"td={td}";
                iIndex++;
            }

            //page number
            if (pn != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"pn={pn}";
                iIndex++;
            }

            //page size
            if (ps != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"ps={ps}";
                iIndex++;
            }


            if (ui != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"ui={ui}";
            }

            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/getCount?" + URLi;

        }


        public void GetIncidentReportSearch(string ss = "", string sk = "", string fd = "", string td = "", string ui = "", string pn = "", string ps = "")
        {
            int iIndex = 0;
            URLi = "";

            //"ss=abc&sk=xyz&fd=123&td=235&ui=jjj"

            if ((ss == "") && (sk == "") && (fd == "") && (td == "") && (ui == "") && (pn == "") && (ps == ""))
            {
                URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/list";
                return;
            }

            if (ss != "")
            {
                URLi = URLi + $"ss={ss}";
                iIndex++;
            }

            if (sk != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"sk={sk}";
                iIndex++;
            }

            if (fd != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"fd={fd}";
                iIndex++;
            }

            if (td != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"td={td}";
                iIndex++;
            }

            if (ui != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"ui={ui}";
                iIndex++;
            }

            //page number
            if (pn != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"pn={pn}";
                iIndex++;
            }

            //page size
            if (ps != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"ps={ps}";
                iIndex++;
            }

            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/list?" + URLi;

        }



        //POST calls
        public void CreateIncidentReport(Report report)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport";
            sMessage = JsonConvert.SerializeObject(report);
        }

        //PUT calls
        public void AssignIncidentReport(string reportId, AssignReport assign)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}/assign";

            sMessage = JsonConvert.SerializeObject(assign);
        }

        //submit to approve
        public void ApproveIncidentReport(string reportId, string eTag)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}/approve?etag={eTag}";
        }

        //submit to reject 
        public void RejectIncidentReport(string reportId, string eTag)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}/reject?etag={eTag}";
        }

        public void UpdateIncidentReport(string reportId, UpdateReport report)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}";

            sMessage = JsonConvert.SerializeObject(report);
        }


        //DELETE calls
        public void DeleteIncidentReport(string reportId)
        {
            URLi = $"{protocol}://{serverName}/v{version}/IncidentReport/{reportId}";
        }

    }
}
