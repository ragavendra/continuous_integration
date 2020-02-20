using System;
using System.Collections.Generic;

namespace PortalApp.Models
{
    public class Report
    {
        public string creatorId { get; set; }
        public string empId { get; set; }
        public string creatorDisplayName { get; set; }
        public string creatorEmail { get; set; }
        public string incidentDate { get; set; }
        public string incidentStartTime { get; set; }
        public string incidentEndTime { get; set; }
        public string supervisorId { get; set; }
        public string supervisor { get; set; }
        public string station { get; set; }
        public string incidentType { get; set; }
        public string guideway { get; set; }
        public string trainId { get; set; }
        public string vehicleId1 { get; set; }
        public string passengers1 { get; set; }
        public string vehicleId2 { get; set; }
        public string passengers2 { get; set; }
        public string vehicleId3 { get; set; }
        public string passengers3 { get; set; }
        public string vehicleId4 { get; set; }
        public string passengers4 { get; set; }
        public string vehicleId5 { get; set; }
        public string passengers5 { get; set; }
        public string vehicleId6 { get; set; }
        public string passengers6 { get; set; }
        public string directionOfTravel { get; set; }
        public string causeOfEmergencyBrake { get; set; }
        public string isConfirmed { get; set; }
        public string ebReason { get; set; }
        public bool isNoInjuryConfirmed { get; set; }

    }

    public class ReportResponse
    {
        public string reportId { get; set; }
        public string reportName { get; set; }
        public string status { get; set; }
        public string creatorId { get; set; }
        public string empId { get; set; }
        public string creatorDisplayName { get; set; }
        public string creatorEmail { get; set; }
        public DateTime incidentDate { get; set; }
        public string incidentStartTime { get; set; }
        public string incidentEndTime { get; set; }
        public string supervisorId { get; set; }
        public string supervisor { get; set; }
        public string station { get; set; }
        public string incidentType { get; set; }
        public string guideway { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime lastUpdated { get; set; }
        public string trainId { get; set; }
        public string vehicleId1 { get; set; }
        public string passengers1 { get; set; }
        public string vehicleId2 { get; set; }
        public string passengers2 { get; set; }
        public string vehicleId3 { get; set; }
        public string passengers3 { get; set; }
        public string vehicleId4 { get; set; }
        public string passengers4 { get; set; }
        public string vehicleId5 { get; set; }
        public string passengers5 { get; set; }
        public string vehicleId6 { get; set; }
        public string passengers6 { get; set; }
        public string directionOfTravel { get; set; }
        public string causeOfEmergencyBrake { get; set; }
        public string isConfirmed { get; set; }
        public string ebReason { get; set; }
        public bool isNoInjuryConfirmed { get; set; }
        public string eTag { get; set; }
        public DateTime timeStamp { get; set; }
    }

    public class AssignReport
    {
        public string supervisorId { get; set; }
        public string supervisor { get; set; }
        public string eTag { get; set; }
    }

    public class UpdateReport
    {
        public string empId { get; set; }
        public string incidentDate { get; set; }
        public string incidentStartTime { get; set; }
        public string incidentEndTime { get; set; }
        public string station { get; set; }
        public string incidentType { get; set; }
        public string guideway { get; set; }
        public string trainId { get; set; }
        public string vehicleId1 { get; set; }
        public string passengers1 { get; set; }
        public string vehicleId2 { get; set; }
        public string passengers2 { get; set; }
        public string vehicleId3 { get; set; }
        public string passengers3 { get; set; }
        public string vehicleId4 { get; set; }
        public string passengers4 { get; set; }
        public string vehicleId5 { get; set; }
        public string passengers5 { get; set; }
        public string vehicleId6 { get; set; }
        public string passengers6 { get; set; }
        public string directionOfTravel { get; set; }
        public string causeOfEmergencyBrake { get; set; }
        public string isConfirmed { get; set; }
        public string ebReason { get; set; }
        public bool isNoInjuryConfirmed { get; set; }
        public string eTag { get; set; }
    }

    public class List
    {
        public string reportId { get; set; }
        public string reportName { get; set; }
        public string status { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class ReportSearch
    {
        public List<List> list { get; set; }
    }

}