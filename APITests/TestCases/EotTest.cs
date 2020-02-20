using System.Net;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace PortalApp
{
    public class EotTest : TestFixture
    {

        //[Ignore("Requires lot of bandwidth")]
        [TestCase(TestName = "Get bus statuses - All"), Order(0)]
        public void GetBusStatusesAll() 
        {

            EOT eot = new EOT();
            eot.BusStatuses();
            //var respo = eot.performGetOpn();
            var respo = eot.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");


            JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {resp}");

            System.Threading.Thread.Sleep(1000);

            /*
             Response is {
  "response": [
    {
      "vehicleNo": "11302",
      "tripId": 11154030,
      "routeNo": "262",
      "direction": "SOUTH",
      "destination": "CAULFEILD",
      "pattern": "SB1EX",
      "lat": 49.373483,
      "long": -123.273933,
      "recordedTime": "2019-11-07T10:00:04",
      "routeMap": "http://dummypath/262.kml",
      "opDate": "2019-11-07T00:00:00"
    },
             */

        }

        [TestCase(TestName = "Get bus statuses - Verify Route Filter"),TestCaseSource(typeof(Data), "RouteNo"), Order(2)]
        public void GetBusStatuses(string route) 
        {

            EOT eot = new EOT();
            eot.BusStatuses(route);
            //var respo = eot.performGetOpn();
            var respo = eot.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching");

            JObject resp = JObject.Parse(respo.response);


            foreach (var vehicle in resp["response"])
                Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Get bus statuses history - By date and time"), Order(4)]
        public void GetBusStatusesHistory() 
        {

            EOT eot = new EOT();
            //yesterday
            string timestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            eot.BusStatusesHistory(timestamp);
            //var respo = eot.performGetOpn();
            var respo = eot.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching");

            JObject resp = JObject.Parse(respo.response);

            /*
             * {
    "response": [],
    "error": null,
    "requestId": "8f19615c-f889-45b6-94b0-1925acd3de71",
    "statusCode": 200
}
             */

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(1000);

        }


        [TestCase(TestName = "Get bus statuses time lapse - Yesterday"), Order(6)]
        public void GetBusStatusesTimeLapse() 
        {

            //yesterday
            string fromTimestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string toTimestamp = Constants.now.AddDays(-1).AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
            EOT eot = new EOT();
            eot.BusStatusesTimeLapse(fromTimestamp, toTimestamp, "45");
            //var respo = eot.performGetOpn();
            var respo = eot.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching");

            JObject resp = JObject.Parse(respo.response);

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(1000);

        }


        [TestCase(TestName = "Get status - By request id"), Order(6)]
        public void GetStatus() 
        {

            //yesterday
            string fromTimestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string toTimestamp = Constants.now.AddDays(-1).AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
            EOT eot = new EOT();
            eot.BusStatusesTimeLapse(fromTimestamp, toTimestamp, "45");
            //var respo = eot.performGetOpn();
            var respo = eot.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(100 * 1000);

            eot.Status(resp["requestId"].ToString());
            eot.Get();

            respo = eot.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            resp = JObject.Parse(respo.response);

            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(1000);

        }




        /*

        [TestCase(TestName = "Compare get schedule and buses"), TestCaseSource(typeof(Data), "StopCountTime"), Order(2)]
        public void GetScheduleAndBuses(string stopNo, string count, string time, string route) 
        {
           
        }*/

    }
}
