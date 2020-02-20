using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class CIRListTest : TestFixture
    {

        [TestCase(TestName = "CIR List by id"), Order(0)]
        public void CIRListById()
        {

            //search by CIR no, vehicle no or Operator no.
            CIRList cirList = new CIRList();

            cirList.searchCir("2019-11-01", getDateTimeRFC3339(DateTime.Today));

            var respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");
            var cirs = JsonConvert.DeserializeObject<List<Models.CIRList>>(respo.response);

            var iRand = new Random();
            var cirNo = cirs[iRand.Next(0, cirs.Count)].cirNo;

            cirList.GetCIR(cirNo);
            respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");
            var cir = JsonConvert.DeserializeObject<Models.CIRList>(respo.response);
            Assert.AreEqual(cirNo, cir.cirNo, $"CIR no does not match Expected - {cirNo}, Actual - {cir.cirNo}");
        }

        [TestCase(TestName = "CIR List search criteria"),TestCaseSource(typeof(Data), "CIRList"), Order(02)]
        public void CIRListSearchCriteria(int fromDate, int toDate, string search)
        {

            //search by CIR no, vehicle no or Operator no.
            CIRList cirList = new CIRList();

            DateTime fromDt = DateTime.Now.AddDays(fromDate);
            DateTime toDt = DateTime.Now.AddDays(toDate);

            cirList.searchCir(getDateTimeRFC3339(fromDt), getDateTimeRFC3339(toDt), search);

            var respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");

            //check the response
            srchCIR(fromDt, toDt, search, respo.response);

            var cirs = JsonConvert.DeserializeObject<List<Models.CIRList>>(respo.response);
            if (cirs.Count < 1)
            {
                Assert.Warn("No results for search criteria. Exiting!");
                return;
            }

            var rand = new Random();
            //int rndNo = rand.Next(0, cirs.Count);

            do
            {
                //search by CIR#
                search = cirs[rand.Next(0, cirs.Count)].cirNo;
                
            } while (search == null);

            cirList.searchCir(getDateTimeRFC3339(fromDt), getDateTimeRFC3339(toDt), search);

            respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");

            //check the response
            srchCIR(fromDt, toDt, search, respo.response, cirSearch.cirNo);

            do
            {
                //search by Vehicle No#
                search = cirs[rand.Next(0, cirs.Count)].vehicleNo;
                
            } while (search == null);

            cirList.searchCir(getDateTimeRFC3339(fromDt), getDateTimeRFC3339(toDt), search);

            respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");

            //check the response
            srchCIR(fromDt, toDt, search, respo.response, cirSearch.vehicleNo);

            do
            {
                //search by Operator No#
                search = cirs[rand.Next(0, cirs.Count)].driver;
                
            } while (search == null);

            cirList.searchCir(getDateTimeRFC3339(fromDt), getDateTimeRFC3339(toDt), search);

            respo = cirList.Get();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 - {respo.status}");

            //check the response
            srchCIR(fromDt, toDt, search, respo.response, cirSearch.opNo);
        }

        public void srchCIR(DateTime fromDate, DateTime toDate, string search, string response, cirSearch? srchCriteria = null)
        {
            var cirs = JsonConvert.DeserializeObject<List<Models.CIRList>>(response);

            //check if search worked
            foreach (var cir in cirs)
            {
                Assert.GreaterOrEqual(cir.eventDate.Date, fromDate.Date, $"Search is not working for from date '{getDateTimeRFC3339(fromDate)}'. It has {cir.eventDate} for {cir.cirNo}");
                Assert.LessOrEqual(cir.eventDate.Date, toDate.Date, $"Search is not working for to date '{getDateTimeRFC3339(toDate)}'. It has {cir.eventDate} for {cir.cirNo}");
                Assert.That(cir.cirNo.Contains(search) || cir.vehicleNo.Contains(search) || cir.driver.Contains(search), $"Unable to find {search} in CIR - {cir.cirNo} or Vehicle - {cir.vehicleNo} or Operator - {cir.driver}");

                switch (srchCriteria)
                {
                    case cirSearch.cirNo:
                        Assert.That(cir.cirNo.Contains(search), $"Unable to find {search} in CIR - {cir.cirNo}");
                        break;

                    case cirSearch.vehicleNo:
                        Assert.That(cir.vehicleNo.Contains(search), $"Unable to find {search} in CIR - {cir.vehicleNo}");
                        break;

                    case cirSearch.opNo:
                        Assert.That(cir.driver.Contains(search), $"Unable to find {search} in CIR - {cir.driver}");
                        break;

                    default:
                        break;

                }
            }

        }

        public enum cirSearch
        {
            cirNo = 0, vehicleNo = 1, opNo = 2
        }

        public string getDateTimeRFC3339(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }


    }
}
