using System;
using System.Collections.Generic;

namespace PortalApp.Models
{
    public class CIRList
    {
        public string cirNo { get; set; }
        public string incidentCode { get; set; }
        public string incidentName { get; set; }
        public string vehicleNo { get; set; }
        public string lineBlock { get; set; }
        public string lastStop { get; set; }
        public string direction { get; set; }
        public string driver { get; set; }
        public DateTime eventDate { get; set; }
        public string eventDateId { get; set; }
        public string lineGroup { get; set; }
        public string delay { get; set; }
        public string vehicleType { get; set; }
        public string vehicleModel { get; set; }
        public string license { get; set; }
        public string dateInService { get; set; }
        public string serviceDiverted { get; set; }
        public string serviceLost { get; set; }
        public object worksafe { get; set; }
        public string priority { get; set; }
        public string pretrip { get; set; }
        public object incidentType { get; set; }
        public object comments { get; set; }
        public string supervisor { get; set; }
        public object primary { get; set; }
        public object secondary { get; set; }
        public string police { get; set; }
        public object jurisdiction { get; set; }
        public string ehs { get; set; }
        public string transported { get; set; }
        public object location { get; set; }
        public object assignTime { get; set; }
        public object supportUnit { get; set; }
        public object deffuserPaged { get; set; }
        public string status { get; set; }
        public string author { get; set; }
        public string depot { get; set; }
        public string casr { get; set; }
        public string distanceDriven { get; set; }
        public object majorIncident { get; set; }
        public object minorIncident { get; set; }
        public object id { get; set; }
    }

    public class Feedback
    {
        public string feedbackId { get; set; }
        public string userId { get; set; }
        public string empId { get; set; }
        public string userDisplayName { get; set; }
        public string userEmail { get; set; }
        public DateTime feedbackDate { get; set; }
        public string featureId { get; set; }
        public string comment { get; set; }
    }

    public class FeedbackList
    {
        public List<Feedback> list { get; set; }
    }

}