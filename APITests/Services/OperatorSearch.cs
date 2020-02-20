using System;
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{

    public class OperatorSearch : Rest
    {

        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.authorizationVersion;

        //GET calls
        public void GetDetails(string employeeId)
        {
            URLi = $"{protocol}://{serverName}/operatorsearch/api/v{version}/OperatorSearch/Details/{employeeId}";
        }

        public void Search(string query)
        {
            URLi = $"{protocol}://{serverName}/operatorsearch/api/v{version}/OperatorSearch/Search?query={query}";
        }

    }
}
