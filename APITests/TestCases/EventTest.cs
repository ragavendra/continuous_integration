using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class EventTest : TestFixture
    {

        [TestCase(TestName = "Event by id"), Order(0)]
        public void EventById()
        {

            //search by CIR no, vehicle no or Operator no.
            Event event_ = new Event();
            event_.GetEventByDate("2019-11-01", getDateTimeRFC3339(DateTime.Today));


            var respo = event_.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");
            var events = JsonConvert.DeserializeObject(respo.response);
            //var events = JsonConvert.DeserializeObject<List<List<Models.Event>>>(respo.response);

            JObject resp = JObject.Parse(respo.response);

            /*
            var iRand = new Random();
            var cirNo = cirs[iRand.Next(0, cirs.Count)].cirNo;

            event_.GetEvent();
            cirList.GetCIR(cirNo);
            respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");
            var cir = JsonConvert.DeserializeObject<Models.CIRList>(respo.response);
            Assert.AreEqual(cirNo, cir.cirNo, $"CIR no does not match Expected - {cirNo}, Actual - {cir.cirNo}");
            */

            foreach (var event_1 in resp.First)
                TestContext.WriteLine(event_1["title"].ToString());

        }

        public string getDateTimeRFC3339(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }


    }
}
