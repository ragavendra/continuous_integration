using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using PortalApp.Models;
using System.Collections.Generic;

namespace PortalApp
{
    public class TransitSupervisorTest : TestFixture
    {

        [TestCase(TestName = "Get bus cancellation last update"), Order(0)]
        public void GetBusStatusesAll() 
        {

            TransitSupervisor transSup = new TransitSupervisor();
            transSup.GetBusCancellationLastUpdate();

            //var respo = transSup.performGetOpn();
            var respo = transSup.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            JObject resp = JObject.Parse(respo.response);

            TestContext.WriteLine($"Response is {resp}");

        }

        [TestCase(TestName = "Get cancelled bus statuses"), TestCaseSource(typeof(Data), "CancelledWhen"), Order(2)]
        public void GetBusStatuses(string when)
        {

            TransitSupervisor transSup = new TransitSupervisor();
            transSup.GetBusCancellation(when);
            //var respo = transSup.performGetOpn();
            var respo = transSup.Get();

            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching")

            var resp = JsonConvert.DeserializeObject<List<BusCancellations>>(respo.response);

            foreach (var cancellation in resp)
                Assert.AreEqual(when, cancellation.category, $"Category filter is not working for {when}");

        }


        [TestCase(TestName = "File service - Get file"),TestCaseSource(typeof(Data), "File"), Order(4)]
        public void GetFile(string featur, string filename, int statusCode) 
        {

            File file = new File();
            file.GetFile(featur, filename);
            //var respo = eot.performGetOpn();
            var respo = file.Get();

            Assert.AreEqual(statusCode, (int) respo.status, $"Status code is not {statusCode}");

            //Assert.AreEqual(resp.Item1, resp.Item2, "Responses are not matching");

            //JObject resp = JObject.Parse(respo.response);


            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

              ;


        }


    }
}
