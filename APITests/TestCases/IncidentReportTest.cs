using System;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class IncidentReportTest : TestFixture
    {

        [TestCase(TestName = "Incident report workflow"), Order(0)]
        public void IncidentReportWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            IncidentReport incidentReport = new IncidentReport();
            Report incReport = new Report();
            incReport.creatorId = "abc";
            incReport.empId = "ABC";
            incReport.creatorDisplayName = "ABC";
            incReport.creatorId = "David.Liang@Translink.ca";
            incReport.creatorEmail = "David.Liang@Translink.ca";
            incReport.incidentDate = Constants.now.ToString("yyyy-MM-ddT00:00:00");
            incReport.incidentStartTime = "10:00";
            incReport.incidentEndTime = "11:00";
            incReport.supervisorId = "DARREN.BALLANCE@BCRTC.CA";
            incReport.supervisor = "BALLANCE, DARREN";
            incReport.station = "Burrard";
            incReport.trainId = "201";
            incReport.vehicleId1 = "203";
            incReport.passengers1 = "11";
            incReport.vehicleId2 = "205";
            incReport.passengers2 = "21";
            incReport.directionOfTravel = "Zero";
            incReport.causeOfEmergencyBrake = "Train";
            incReport.isConfirmed = "Confirmed";
            incReport.ebReason = "Weather";
            incReport.isNoInjuryConfirmed = true;

            //CREATE incident report
            incidentReport.CreateIncidentReport(incReport);

            var respo = incidentReport.Post();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            var resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(incReport.creatorEmail, resp.creatorEmail, "Creator email does not match");
            Assert.AreEqual(incReport.empId, resp.empId, "Employee id does not match");
            Assert.AreEqual("Submitted", resp.status, "Status is not submitted");
            string reportId = resp.reportId;

            //GET and verify inc rep
            incidentReport.GetIncidentReport(reportId);
            respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(incReport.creatorEmail, resp.creatorEmail, "Creator email does not match");
            Assert.AreEqual(incReport.empId, resp.empId, "Employee id does not match");
            Assert.AreEqual("Submitted", resp.status, "Status is not submitted");

            UpdateReport update = new UpdateReport();

            update.empId = "ABCd";
            update.incidentDate = Constants.now.AddDays(-1).ToString("yyyy-MM-ddT00:00:00");
            update.incidentStartTime = "11:00";
            update.incidentEndTime = "12:00";
            update.station = "Sapperton";
            update.trainId = "205";
            update.vehicleId1 = "200";
            update.passengers1 = "12";
            update.vehicleId2 = "204";
            update.passengers2 = "24";
            update.directionOfTravel = "One";
            update.causeOfEmergencyBrake = "GIMS";
            update.isConfirmed = "Unconfirmed";
            update.ebReason = "Animal";
            update.isNoInjuryConfirmed = false;
            update.eTag = resp.eTag;

            //UPDATE report
            incidentReport.UpdateIncidentReport(reportId, update);
            respo = incidentReport.Put();
            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(update.empId, resp.empId, $"Emp id does not match {respo.response}");
            Assert.AreEqual(update.incidentStartTime, resp.incidentStartTime, "Does not match");
            Assert.AreEqual(update.incidentEndTime, resp.incidentEndTime, "Does not match");
            Assert.AreEqual(update.station, resp.station, "Does not match");
            Assert.AreEqual(update.trainId, resp.trainId, "Does not match");
            Assert.AreEqual(update.vehicleId1, resp.vehicleId1, "Does not match");
            Assert.AreEqual(update.passengers1, resp.passengers1, "Does not match");
            Assert.AreEqual(update.vehicleId2, resp.vehicleId2, "Does not match");
            Assert.AreEqual(update.passengers2, resp.passengers2, "Does not match");
            Assert.AreEqual(update.directionOfTravel, resp.directionOfTravel, "Does not match");
            Assert.AreEqual(update.causeOfEmergencyBrake, resp.causeOfEmergencyBrake, "Does not match");
            Assert.AreEqual(update.isConfirmed, resp.isConfirmed, "Does not match");
            Assert.AreEqual(update.ebReason, resp.ebReason, "Does not match");
            Assert.AreEqual(update.isNoInjuryConfirmed, resp.isNoInjuryConfirmed, "Does not match");
            //Assert.AreEqual(assign.eTag, resp.eTag, "Supervisor eTag does not match");
            Assert.AreEqual("Submitted", resp.status, "Status is not submitted");


            AssignReport assign = new AssignReport();
            assign.supervisor = "BALLANCE, DARRE";
            assign.supervisorId = "DARREN.BALLANC@BCRTC.CA";
            assign.eTag = resp.eTag;


            //ASSIGN report
            incidentReport.AssignIncidentReport(reportId, assign);
            respo = incidentReport.Put();
            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(assign.supervisor, resp.supervisor, "Supervisor does not match");
            Assert.AreEqual(assign.supervisorId, resp.supervisorId, "Supervisor id does not match");
            //Assert.AreEqual(assign.eTag, resp.eTag, "Supervisor eTag does not match");
            Assert.AreEqual("Submitted", resp.status, "Status is not submitted");

            //APPROVE report
            incidentReport.ApproveIncidentReport(reportId, resp.eTag);
            respo = incidentReport.Put();
            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual("Approved", resp.status, "Status is not approved");

            //REJECT report
            incidentReport.RejectIncidentReport(reportId, resp.eTag);
            respo = incidentReport.Put();
            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual("Rejected", resp.status, "Status is not rejected");

            //DELETE report
            incidentReport.DeleteIncidentReport(reportId);
            respo = incidentReport.Delete();
            resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            //check if DELETED
            incidentReport.GetIncidentReport(reportId);
            respo = incidentReport.Get();
            Assert.AreEqual(204, (int) respo.status, "Status code is not 204");


        }


        [TestCase(TestName = "Incident report and count search"), Order(2)]
        public void IncidentReportSearch()
        {

            IncidentReport incidentReport = new IncidentReport();
            Report incReport = new Report();
            incReport.creatorId = "abc";
            incReport.empId = "XYZ";
            incReport.creatorDisplayName = "ABC";
            incReport.creatorId = "David.Liang@Translink.ca";
            incReport.creatorEmail = "David.Liang@Translink.ca";
            //create report for yesterday
            DateTime yesterday = Constants.now.AddDays(-1);
            incReport.incidentDate = yesterday.ToString("yyyy-MM-ddT00:00:00");
            incReport.incidentStartTime = "10:00";
            incReport.incidentEndTime = "11:00";
            incReport.supervisorId = "DARREN.BALLANCE@BCRTC.CA";
            incReport.supervisor = "BALLANCE, DARREN";
            incReport.station = "Burrard";
            incReport.trainId = "201";
            incReport.vehicleId1 = "203";
            incReport.passengers1 = "11";
            incReport.vehicleId2 = "205";
            incReport.passengers2 = "21";
            incReport.directionOfTravel = "Zero";
            incReport.causeOfEmergencyBrake = "Train";
            incReport.isConfirmed = "Confirmed";
            incReport.ebReason = "Weather";
            incReport.isNoInjuryConfirmed = true;

            //CREATE incident report
            incidentReport.CreateIncidentReport(incReport);

            var respo = incidentReport.Post();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            var resp = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
            Assert.AreEqual(incReport.creatorEmail, resp.creatorEmail, "Creator email does not match");
            Assert.AreEqual(incReport.empId, resp.empId, "Employee id does not match");
            Assert.AreEqual("Submitted", resp.status, "Status is not submitted");
            string reportId = resp.reportId;


            string sk = "XYZ";

            //CREATE incident report
            incidentReport.GetIncidentReportSearch("all", sk, yesterday.AddDays(-1).ToString("yyyy-MM-dd"), yesterday.AddDays(2).ToString("yyyy-MM-dd"), "David.Liang@Translink.ca");

            respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            var resp1 = JsonConvert.DeserializeObject<ReportSearch>(respo.response);

            foreach (var item in resp1.list)
            {
                Assert.True(item.reportName.Contains(sk), $"Report does not contain {sk}");
                TestContext.WriteLine($"Report: {item.reportName}");

            }

            //incident report count
            incidentReport.GetIncidentReportCount("all", sk, yesterday.AddDays(-1).ToString("yyyy-MM-dd"), yesterday.AddDays(2).ToString("yyyy-MM-dd"), "David.Liang@Translink.ca");

            respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");
            Assert.AreEqual(1, Int32.Parse(respo.response), $"Status code is not 200 - {respo.response}");

            //incidentReport.Print().P


            //DELETE report
            incidentReport.DeleteIncidentReport(reportId);
            respo = incidentReport.Delete();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            //TestContext.WriteLine($"Result count is {respo.response}");
        }


        [TestCase(TestName = "Incident report and count from date search"), Order(6)]
        public void IncidentReportFromDateSearch()
        {

            string sk = "";
            DateTime fromDay = Constants.now.AddDays(-10);
            IncidentReport incidentReport = new IncidentReport();

            //GET incident report
            incidentReport.GetIncidentReportSearch("", sk, fromDay.ToString("yyyy-MM-dd"),"","","1","99");

            var respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            var resp1 = JsonConvert.DeserializeObject<ReportSearch>(respo.response);
            var resp2 = new ReportResponse();
            int count = resp1.list.Count;

            foreach (var item in resp1.list)
            {

                incidentReport.GetIncidentReport(item.reportId);

                respo = incidentReport.Get();
                Assert.AreEqual(200, (int)respo.status, $"Status code is not 200 - {respo.response}");

                resp2 = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
                Assert.True(resp2.createdOn >= fromDay.Date, $"From date filter did not work for {resp2}");

            }

            //incident report count
            incidentReport.GetIncidentReportCount("", sk, fromDay.ToString("yyyy-MM-dd"));

            respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");
            Assert.AreEqual(count, Int32.Parse(respo.response), $"Results count do not match - {respo.response}");

        }

        [TestCase(TestName = "Incident report and count to date search"), Order(8)]
        public void IncidentReportToDateSearch()
        {

            string sk = "";
            DateTime toDay = Constants.now.AddDays(-1);
            DateTime fromDay = Constants.now.AddDays(-5);
            IncidentReport incidentReport = new IncidentReport();

            //GET incident report
            incidentReport.GetIncidentReportSearch("", sk, fromDay.ToString("yyyy-MM-dd"), toDay.ToString("yyyy-MM-dd"), "", "1", "99");

            var respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");

            var resp1 = JsonConvert.DeserializeObject<ReportSearch>(respo.response);
            var resp2 = new ReportResponse();
            int count = resp1.list.Count;

            foreach (var item in resp1.list)
            {

                incidentReport.GetIncidentReport(item.reportId);

                respo = incidentReport.Get();
                Assert.AreEqual(200, (int)respo.status, $"Status code is not 200 - {respo.response}");

                resp2 = JsonConvert.DeserializeObject<ReportResponse>(respo.response);
                Assert.True(resp2.createdOn.Date <= toDay.Date.AddDays(1).Date, $"From date filter did not work for {resp2}");

            }

            //incident report count
            incidentReport.GetIncidentReportCount("", sk, fromDay.ToString("yyyy-MM-dd"), toDay.ToString("yyyy-MM-dd"), "", "1", "99");

            respo = incidentReport.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.response}");
            Assert.AreEqual(count, Int32.Parse(respo.response), $"Results count do not match - {respo.response}");

        }



        //[TestCase(TestName = "Incident report and count from date search errors"), Order(10)]
        [TestCase(TestName = "Incident report and count from date search errors"),TestCaseSource(typeof(Data), "IncidentReportErrors"), Order(10)]
        public void IncidentReportSearchErrors(string fromDate, string toDate, string pageNo, string pageSize)
        {

            string sk = "";
            IncidentReport incidentReport = new IncidentReport();

            //GET incident report
            incidentReport.GetIncidentReportSearch("", sk, fromDate, toDate,"", pageNo, pageSize);

            var respo = incidentReport.Get();
            Assert.AreEqual(400, (int) respo.status, $"Status code is not 400 - {respo.status}");
            checkErrors(respo.response, fromDate, toDate, pageNo, pageSize);

            //incident report count
            //incidentReport.GetIncidentReportCount("", sk, fromDate);
            incidentReport.GetIncidentReportCount("", sk, fromDate, toDate,"");

            respo = incidentReport.Get();
            Assert.AreEqual(400, (int) respo.status, $"Status code is not 400 - {respo.status}");
            checkErrors(respo.response, fromDate, toDate, pageNo, pageSize);

        }

        public void checkErrors(string respo, string fromDate, string toDate, string pageNo, string pageSize)
        {
            var response = JsonConvert.DeserializeObject<Error>(respo);

            Assert.AreEqual(response.title, "One or more validation errors occurred.", $"Invalid error message title - {response.title}");
            Assert.AreEqual(response.status, 400, $"Invalid status - {response.status}");
            if ((response.errors.fd != null) && response.errors.fd[0] != "")
                Assert.AreEqual(response.errors.fd[0], $"The value '{fromDate}' is not valid.", $"Invalid error message - {response.errors.fd[0]}");
            if ((response.errors.td != null) && response.errors.td[0] != "")
                Assert.AreEqual(response.errors.td[0], $"The value '{toDate}' is not valid.", $"Invalid error message - {response.errors.td[0]}");
            if ((response.errors.pn != null) && response.errors.pn[0] != "")
                Assert.AreEqual(response.errors.pn[0], $"The value '{pageNo}' is not valid.", $"Invalid error message - {response.errors.pn[0]}");
            if ((response.errors.ps != null) && response.errors.ps[0] != "")
                Assert.AreEqual(response.errors.ps[0], $"The value '{pageSize}' is not valid.", $"Invalid error message - {response.errors.ps[0]}");
        }


    }
}
