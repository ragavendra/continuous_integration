using System;
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{

    public class Authorization : Rest
    {

        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.authorizationVersion;

        //GET calls
        public void GetAuthorizationFeatures(string accessRoles)
        {
            URLi = $"{protocol}://{serverName}/authorization/v{version}/Features?accessRoles={accessRoles}";
        }

        public void AccessRoles()
        {
            URLi = $"{protocol}://{serverName}/authorization/v{version}/AccessRoles";
        }

    }
}
