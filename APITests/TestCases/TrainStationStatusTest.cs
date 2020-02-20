using System;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using PortalApp.Models;
using System.Collections.Generic;

namespace PortalApp
{
    public class TrainStationStatusTest : TestFixture
    {

        [TestCase(TestName = "Get skytrain station statuses - All"), Order(0)]
        public void GetTrainStationStatusesAll() 
        {

            TrainStationStatus trainStation = new TrainStationStatus();
            trainStation.GetTrainsStationStatuses();
            var respo = trainStation.Get();

            var trainStations = JsonConvert.DeserializeObject<TrainStationResponse>(respo.response);
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //check if member already exists in the system
            foreach (var station in trainStations.response)
            {
                Assert.That(station.arrival, Is.TypeOf(typeof(DateTime)));
                Assert.That(station.departure, Is.TypeOf(typeof(DateTime)));
                Assert.That(station.platformID, Is.TypeOf(typeof(int)));
                Assert.That(station.sequence, Is.TypeOf(typeof(int)));
                Assert.That(station.passenger, Is.TypeOf(typeof(bool)));
                Assert.That(station.stop, Is.TypeOf(typeof(bool)));
                Assert.That(station.exit, Is.TypeOf(typeof(bool)));
                Assert.That(station.train, Is.TypeOf(typeof(string)));
                Assert.That(station.line, Is.TypeOf(typeof(int)));
                Assert.Contains(station.line, Constants.trainLine, $"Unknown station line {station.line}");
                Assert.AreEqual(station.line, Constants.trainLine[0]);

                //Assert.That(station.terminusPlatformID, Is.TypeOf(typeof(int)));
                //Assert.AreNotEqual(memberId, member.identification, $"Member id - {memberId} exists in the system");
            }

            //JObject resp = JObject.Parse(respo.response);
            //TestContext.WriteLine($"Response is {resp}");

        }

        [TestCase(TestName = "Get skytrain status"), Order(2)]
        public void GetTrainStationStatus() 
        {

            TrainStationStatus trainStation = new TrainStationStatus();
            trainStation.GetTrainStationStatus();
            var respo = trainStation.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get skytrain status - Request id"), Order(6)]
        public void GetTrainStationStatusRequestId() 
        {

            TrainStationStatus trainStation = new TrainStationStatus();
            trainStation.GetTrainStationStatus("123");
            var respo = trainStation.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get skytrain status history"), Order(8)]
        public void GetTrainStationStatusHistory()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            TrainStationStatus trainStation = new TrainStationStatus();
            trainStation.GetTrainStatusHistory(dateTime);
            var respo = trainStation.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

        [TestCase(TestName = "Get skytrain status timelapse"), Order(10)]
        public void GetTrainStationStatusTimelapse()
        {
            //3 days ago history
            DateTime dateTime = DateTime.Now.AddDays(-3);

            TrainStationStatus trainStation = new TrainStationStatus();
            trainStation.GetTrainStatusTimelapse(dateTime, dateTime.AddDays(1), 30);
            var respo = trainStation.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            JObject resp = JObject.Parse(respo.response);
            TestContext.WriteLine($"Response is {resp}");
        }

    }
}
