using System;
using System.Net;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace PortalApp
{
    public class TrainStatusTest : TestFixture
    {

        [TestCase(TestName = "Get trains statuses - All"), Order(0)]
        public void GetTrainStatusesAll() 
        {

            TrainStatus trainStatus = new TrainStatus();
            trainStatus.GetTrainsStatuses();
            var respo = trainStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            TestContext.WriteLine($"Response is {resp}");

        }

        [TestCase(TestName = "Get train status"), Order(2)]
        public void GetTrainStatus() 
        {

            TrainStatus trainStatus = new TrainStatus();
            trainStatus.GetTrainStatus();
            var respo = trainStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get train status - Request id"), Order(6)]
        public void GetTrainStatusRequestId() 
        {

            TrainStatus trainStatus = new TrainStatus();
            trainStatus.GetTrainStatus("123");
            var respo = trainStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get train status history"), Order(8)]
        public void GetTrainStatusHistory()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            TrainStatus trainStatus = new TrainStatus();
            trainStatus.GetTrainStatusHistory(dateTime);
            var respo = trainStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get train status timelapse"), Order(10)]
        public void GetTrainStatusTimelapse()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            TrainStatus trainStatus = new TrainStatus();
            trainStatus.GetTrainStatusTimelapse(dateTime, dateTime.AddDays(1), 30);
            var respo = trainStatus.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }


    }
}
