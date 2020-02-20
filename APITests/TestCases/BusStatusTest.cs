using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using PortalApp.Models;

namespace PortalApp
{
    public class BusStatusTest : TestFixture
    {

        [TestCase(TestName = "Get buses statuses - All"), Order(0)]
        public void GetBusStatusesAll() 
        {

            BusStatus busStatus = new BusStatus();
            busStatus.GetBusStatuses();
            var respo = busStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            TestContext.WriteLine($"Response is {resp}");

        }

        [TestCase(TestName = "Get bus status"), Order(2)]
        public void GetBusStatus() 
        {

            BusStatus busStatus = new BusStatus();
            busStatus.GetBusStatus();
            var respo = busStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }


        [TestCase(TestName = "Get bus status - Request id"), Order(6)]
        public void GetBusStatusRequestId() 
        {

            BusStatus busStatus = new BusStatus();
            busStatus.GetBusStatus();
            var respo = busStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            //JObject resp = JObject.Parse(respo.response);
            var busStat = JsonConvert.DeserializeObject<BusStatus_>(respo.response);

            busStatus.GetBusStatus(busStat.requestId);
            respo = busStatus.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            //JObject resp = JObject.Parse(respo.response);
            var busStat_ = JsonConvert.DeserializeObject<BusStatus_>(respo.response);
            Assert.AreEqual(busStat.requestId, busStat_.requestId, $"Request id {busStat_.requestId} does not match");
        }

        [TestCase(TestName = "Get bus status history"), Order(8)]
        public void GetBusStatusHistory()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            BusStatus busStatus = new BusStatus();
            busStatus.GetBusStatusHistory(dateTime);
            var respo = busStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get bus status timelapse"), Order(10)]
        public void GetBusStatusTimelapse()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            BusStatus busStatus = new BusStatus();
            busStatus.GetBusStatusTimelapse(dateTime, dateTime.AddDays(1), 30);
            var respo = busStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }


    }
}
