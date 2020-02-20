using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using PortalApp.Models;

namespace PortalApp
{
    public class SheetScheduleTest : TestFixture
    {



        [TestCase(TestName = "Get route maps"), TestCaseSource(typeof(Data), "RouteMaps"), Order(0)]
        public void GetRouteMaps(string serviceType, string busCategory)
        {

            SheetSchedule routeMaps = new SheetSchedule();
            routeMaps.GetRouteMaps(serviceType, busCategory);

            var respo = routeMaps.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var routeMaps_ = JsonConvert.DeserializeObject<List<RouteMap>>(respo.response);

            foreach (var routeMap in routeMaps_)
            {
                Assert.AreEqual(serviceType, routeMap.ServiceType, $"Service type do not match");
                Assert.True(routeMap.BusCategoryTags.Contains(busCategory), $"Bus category is not in {routeMap.BusCategoryTags}");
            }


        }

        [TestCase(TestName = "Get paddles"), TestCaseSource(typeof(Data), "Paddles"), Order(2)]
        public void GetPaddles(string serviceType, string busCategory, string depot)
        {

            SheetSchedule paddles = new SheetSchedule();
            paddles.GetPaddles(serviceType, busCategory, depot);

            var respo = paddles.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var paddles_ = JsonConvert.DeserializeObject<List<Paddles>>(respo.response);

            foreach (var paddle in paddles_)
            {
                Assert.AreEqual(serviceType, paddle.serviceType, $"Service type do not match");
                Assert.True(paddle.busCategoryTags.Contains(busCategory), $"Bus category is not in {paddle.busCategoryTags}");
            }

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstSmallNumbers = numbers.TakeWhile((o, index) => o >= index);
            Console.WriteLine(string.Join(" ", firstSmallNumbers));

        }


        [TestCase(TestName = "Get headways"), TestCaseSource(typeof(Data), "RouteMaps"), Order(6)]
        public void GetHeadways(string serviceType, string busCategory)
        {

            SheetSchedule headWays = new SheetSchedule();
            headWays.GetHeadways(serviceType, busCategory);

            var respo = headWays.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            /*
            var routeMaps_ = JsonConvert.DeserializeObject<List<RouteMap>>(respo.response);

            foreach (var routeMap in routeMaps_)
            {
                Assert.AreEqual(serviceType, routeMap.ServiceType, $"Service type do not match");
                Assert.True(routeMap.BusCategoryTags.Contains(busCategory), $"Bus category is not in {routeMap.BusCategoryTags}");
            }*/

        }

        [TestCase(TestName = "Get sheet"), Order(6)]
        public void GetSheet()
        {

            SheetSchedule sheet = new SheetSchedule();
            sheet.GetSheet(getDateTimeRFC3339(DateTime.Now.AddDays(-3)));

            var respo = sheet.Get();

            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var sheet_ = JsonConvert.DeserializeObject<Sheet>(respo.response);

        }


        public string getDateTimeRFC3339(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }


    }
}
