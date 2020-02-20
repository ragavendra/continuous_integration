using System;
using System.Collections.Generic;

namespace PortalApp.Models
{

    public class Errors
    {
        public List<string> fd { get; set; }
        public List<string> td { get; set; }
        public List<string> ps { get; set; }
        public List<string> pn { get; set; }
    }

    public class Error
    {
        public Errors errors { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
    }

    public class SecurityError
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string detail { get; set; }
        public string instance { get; set; }
    }

}