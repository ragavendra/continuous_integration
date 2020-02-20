
using System;

namespace PortalApp.Models
{
    public class Features
    {
        public int displayOrder { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string homeScreenIcon { get; set; }
        public object menuIcon { get; set; }
        public string url { get; set; }
        public string parentFeatureId { get; set; }

    }

    public class AccessRoles
    {
        public string roleName { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string parentRoleName { get; set; }
        public DateTime createTimestamp { get; set; }
        public DateTime updateTimestamp { get; set; }
    }

}
