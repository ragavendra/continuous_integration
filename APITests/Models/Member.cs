
using System;
using System.Collections.Generic;

namespace PortalApp.Models
{
    public class Member
    {
        public string hhu { get; set; }
        public string identification { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }

    }

    public class OperatorSearch_
    {
        public string employeeId { get; set; }
        public string seniorityNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobCode { get; set; }
        public string jobDescription { get; set; }
        public string locationCode { get; set; }
        public string locationDescriptionShort { get; set; }
        public string hireDate { get; set; }
        public string id { get; set; }
    }

    public class Event
    {
        public string title { get; set; }
        public string category { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string description { get; set; }
        public string allDayEvent { get; set; }
        public string recurrence { get; set; }
        public DateTime date { get; set; }
        public string enteredBy { get; set; }
        public DateTime dateEnd { get; set; }
        public string contentType { get; set; }
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public DateTime lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string id { get; set; }
    }

}
