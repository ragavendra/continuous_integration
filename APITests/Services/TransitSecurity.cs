
namespace PortalApp
{
    public class TransitSecurity : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void GetAllDocuments()
        {
            URLi = $"{protocol}://{serverName}/policiesandprocedures/api/PoliciesAndProcedures/GetAllDocuments";
        }

        public void GetDocument(string document)
        {
            URLi = $"{protocol}://{serverName}/policiesandprocedures/api/PoliciesAndProcedures/GetDocument/{document}";
        }

    }
}