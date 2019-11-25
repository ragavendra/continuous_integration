using System.Net;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace AppName
{
    public class SomeApp1Test : TestFixture
    {

        //[Ignore("Requires lot of bandwidth")]
        [TestCase(TestName = "Get bus statuses - All"), Order(0)]
        public void GetSomeApp1All() 
        {

			Someapp1 someapp1 = new Someapp1();
            someapp1.SomeApp1_();
            //var respo = someapp1.performGetOpn();
            var respo = someapp1.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");


            JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {resp}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Get bus statuses - Verify Route Filter"),TestCaseSource(typeof(Data), "RouteNo"), Order(2)]
        public void GetSomeApp1(string route) 
        {
			
			Someapp1 someapp1 = new Someapp1();
            someapp1.SomeApp1_(route);
            //var respo = someapp1.performGetOpn();
            var respo = someapp1.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching");

            JObject resp = JObject.Parse(respo.response);


            foreach (var vehicle in resp["response"])
                Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Get bus statuses history - By date and time"), Order(4)]
        public void GetSomeApp1History() 
        {
			
			Someapp1 someapp1 = new Someapp1();
			
            //yesterday
            string timestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            someapp1.SomeApp1History(timestamp);
            //var respo = someapp1.performGetOpn();
            var respo = someapp1.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(1000);

        }


        [TestCase(TestName = "Get bus statuses time lapse - Yesterday"), Order(6)]
        public void GetSomeApp1TimeLapse() 
        {

			Someapp1 someapp1 = new Someapp1();
			
            //yesterday
            string fromTimestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string toTimestamp = Constants.now.AddDays(-1).AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
            someapp1.SomeApp1TimeLapse(fromTimestamp, toTimestamp, "45");
            //var respo = someapp1.performGetOpn();
            var respo = someapp1.Get();

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
			Someapp1 someapp1 = new Someapp1();
			
            //yesterday
            string fromTimestamp = Constants.now.AddDays(-1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            string toTimestamp = Constants.now.AddDays(-1).AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
            someapp1.SomeApp1TimeLapse(fromTimestamp, toTimestamp, "45");
            //var respo = someapp1.performGetOpn();
            var respo = someapp1.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(100 * 1000);

            someapp1.Status(resp["requestId"].ToString());
            someapp1.Get();

            respo = someapp1.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            resp = JObject.Parse(respo.response);

            Assert.AreEqual(resp["statusCode"].ToString(), "200", "Status code is not 200");
            Assert.IsNull(((Newtonsoft.Json.Linq.JValue)resp["error"]).Value, "Error is not null");

            System.Threading.Thread.Sleep(1000);

        }

    }
}
