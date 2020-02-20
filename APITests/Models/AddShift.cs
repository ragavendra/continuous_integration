using System;
using System.Collections.Generic;

namespace PortalApp.Models
{
    public class Patrol
    {
        public List<string> hubs { get; set; }
        public List<string> areas { get; set; }
    }

    public class AddShift
    {
        public string shiftDate { get; set; }
        public string car { get; set; }
        public string role { get; set; }
        public string shiftType { get; set; }
        public string shiftStartHour { get; set; }
        public string shiftEndHour { get; set; }
        public Patrol patrol { get; set; }
        public List<Member> members { get; set; }
        public string comments { get; set; }
        public string createdTs { get; set; }
        public string createdBy { get; set; }
        public string modifiedTs { get; set; }
        public string modifiedBy { get; set; }
        public object previousRevision { get; set; }
        public string docType { get; set; }
    }
}