using System;
using Newtonsoft.Json;
using PortalApp.Models;

namespace PortalApp
{
    public class File : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.fileVersion;

        //GET calls
        public void GetFile(string feature, string fileName)
        {
            URLi = $"{protocol}://{serverName}/fileservice/v{version}/Files/{feature}/{fileName}";
        }

    }
}
