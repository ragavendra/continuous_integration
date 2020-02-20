using System;
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{

    public class SheetSchedule : Rest
    {

        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.authorizationVersion;

        //GET calls
        public void GetRouteMaps(string serviceType = "", string busCategory = "")
        {
            int iIndex = 0;
            URLi = "";

            if ((serviceType == "") && (busCategory == ""))
            {
                URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/RouteMaps/GetRouteMaps";
                return;
            }

            if (serviceType != "")
            {

                URLi = URLi + $"serviceType={serviceType}";
                iIndex++;
            }

            if (busCategory != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"busCategory={busCategory}";
                iIndex++;
            }

            URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/RouteMaps/GetRouteMaps?" + URLi;

        }

        public void GetPaddles(string serviceType = "", string busCategory = "", string depot = "")
        {
            int iIndex = 0;
            URLi = "";

            if ((serviceType == "") && (busCategory == ""))
            {
                URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Paddles/GetPaddles";
                return;
            }

            if (serviceType != "")
            {

                URLi = URLi + $"serviceType={serviceType}";
                iIndex++;
            }

            if (busCategory != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"busCategory={busCategory}";
                iIndex++;
            }

            if (depot != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"depot={depot}";
                iIndex++;
            }

            URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Paddles/GetPaddles?" + URLi;

        }


        public void GetHeadways(string serviceType = "", string busCategory = "")
        {
            int iIndex = 0;
            URLi = "";

            if ((serviceType == "") && (busCategory == ""))
            {
                URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Headway/GetHeadways";
                return;
            }

            if (serviceType != "")
            {

                URLi = URLi + $"serviceType={serviceType}";
                iIndex++;
            }

            if (busCategory != "")
            {
                if (iIndex > 0)
                    URLi = URLi + "&";

                URLi = URLi + $"busCategory={busCategory}";
                iIndex++;
            }

            URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Headway/GetHeadways?" + URLi;

        }

        public void GetSheet(string pstDateTime = "")
        {
            if (pstDateTime == "")
                URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Sheet/GetSheet";
            else
                URLi = $"{protocol}://{serverName}/sheetapi/api/v{version}/Sheet/GetSheet?pstDateTime={pstDateTime}";
        }

    }
}
