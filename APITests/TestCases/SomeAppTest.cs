using System;
using System.Collections.Generic;
using System.Net;
using AppName.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace AppName
{
    public class SomeAppTest : TestFixture
    {
        protected SomeApp someapp = new SomeApp();

        //[Ignore("Requires lot of bandwidth")]
        [TestCase(TestName = "Save member settings"), Order(0)]
        public void SaveMemberSettings() 
        {

            someapp.SaveMemberToSettings(DateTime.Now.ToString("MMddyyyy_HHmmss"), "First", "Last", "604 111 1111");
            var respo = someapp.Post();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Update shift"), Order(6)]
        public void UpdateShift() 
        {

            someapp.UpdateShift(DateTime.Now.ToString("MMddyyyy_HHmmss"), "09:00", "15:00");
            var respo = someapp.Post();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Update shift hour settings"), Order(8)]
        public void UpdateShiftHourSettings() 
        {

            someapp.UpdateShiftDefaultHoursToSettings(DateTime.Now.ToString("MMddyyyy_HHmmss"), "09:00", "15:00");
            var respo = someapp.Post();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            //JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        //Get calls
        [TestCase(TestName = "Get all settings"), Order(10)]
        public void GetAllSettings() 
        {
            someapp.GetAllSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject<GetAllSettings>(respo.response);
            Assert.IsNotEmpty(response.cars, "Cars is not empty");
            Assert.IsNotEmpty(response.roles, "Roles is not empty");
            Assert.IsNotEmpty(response.shiftHours, "Shift hours is not empty");
            Assert.IsNotEmpty(response.patrolHubs, "Patrol hubs is not empty");
            Assert.IsNotEmpty(response.patrolAreas, "Patrol areas is not empty");
            Assert.IsNotEmpty(response.members, "Members is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get car settings"), Order(12)]
        public void GetCarsSettings() 
        {
            someapp.GetCarsSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get member settings"), Order(14)]
        public void GetMemberSettings() 
        {
            someapp.GetMembersSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject<List<Member>>(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");

            Assert.IsNotEmpty(response[0].identification, "Identification is not empty");
            Assert.IsNotEmpty(response[0].firstName, "First name is not empty");
            Assert.IsNotEmpty(response[0].lastName, "Last name is not empty");
            Assert.IsNotEmpty(response[0].phone, "Phone is not empty");
            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get patrol area settings"), Order(16)]
        public void GetPatrolAreaSettings() 
        {
            someapp.GetPatrolAreasSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get patrol hub settings"), Order(18)]
        public void GetPatrolHubSettings() 
        {
            someapp.GetPatrolHubToSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get roles settings"), Order(20)]
        public void GetRolesSettings() 
        {
            someapp.GetPatrolRolesSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get shift default hours settings"), Order(24)]
        public void GetShiftDefaultHoursSettings() 
        {
            someapp.GetShiftDefaultHoursSettings();
            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject<List<ShiftHour>>(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");
            Assert.IsNotEmpty(response[0].name, "Name is not empty");
            Assert.IsNotEmpty(response[0].startHour, "Start hour is not empty");
            Assert.IsNotEmpty(response[0].endHour, "End hour is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get shifts by date"), Order(26)]
        public void GetShiftsByDate() 
        {
            //shifts for tomorrow
            string timestamp = Constants.now.AddDays(1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            someapp.GetShiftsByDate(timestamp);

            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Get shifts with settings by date"), Order(28)]
        public void GetShiftsWithSettingsByDate() 
        {
            //shifts for tomorrow
            string timestamp = Constants.now.AddDays(1).AddHours(5).ToString("yyyy-MM-ddTHH:mm:ssZ");
            someapp.GetShiftsWithSettingsByDate(timestamp);

            var respo = someapp.Get();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject<GetShiftsWithSettingsByDate>(respo.response);
            //Assert.IsNotEmpty(response, "Cars is not empty");
            Assert.IsNotEmpty(response.settings.cars, "Cars is not empty");
            Assert.IsNotEmpty(response.settings.roles, "Roles is not empty");
            Assert.IsNotEmpty(response.settings.shiftHours, "Shift hours is not empty");
            Assert.IsNotEmpty(response.settings.patrolHubs, "Patrol hubs is not empty");
            Assert.IsNotEmpty(response.settings.patrolAreas, "Patrol areas is not empty");
            Assert.IsNotEmpty(response.settings.members, "Members is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Add member settings"), Order(30)]
        public void AddMemberSettings()
        {

            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddMemberToSettings(timestamp, "First", "Last", "604 111 1111");
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Member not found/ added to the list");

            //JObject resp = JObject.Parse(respo.response);

            //foreach (var vehicle in resp["response"])
              //  Assert.AreEqual(vehicle["routeNo"].ToString(), route, $"Route no filter is not working for {route}");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }


        [TestCase(TestName = "Add car to settings"), Order(32)]
        public void AddCarToSettings()
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddCarToSettings(timestamp);
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Car not found/ added to the list");
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Add patrol area to settings"), Order(34)]
        public void AddPatrolAreaToSettings()
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddPatrolAreaToSettings(timestamp);
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Patrol area not found/ added to the list");
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Add patrol hub to settings"), Order(36)]
        public void AddPatrolHubToSettings()
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddPatrolHubToSettings(timestamp);
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Patrol hub not found/ added to the list");
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Add role to settings"), Order(38)]
        public void AddRoleToSettings()
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddRoleToSettings(timestamp);
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Role not found/ added to the list");
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Add shift to settings"), Order(42)]
        public void AddShiftToSettings()
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddShift(timestamp);
            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Shift not found/ added to the list");
            //Assert.IsNotEmpty(response, "Cars is not empty");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }


        //DELETE calls
        [TestCase(TestName = "Delete car settings"), Order(44)]
        public void DeleteCarSettings() 
        {
            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddCarToSettings(timestamp);

            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Car not found/ added to the list");

            someapp.DeleteCarFromSettings(timestamp);
            respo = someapp.Delete();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(!response.ToString().Contains(timestamp), "Car still exists in the list");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);

        }

        [TestCase(TestName = "Delete member settings"), Order(46)]
        public void DeleteMemberSettings() 
        {

            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddMemberToSettings(timestamp, "First", "Last", "604 111 1111");

            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Member not found/ added to the list");

            someapp.DeleteMemberFromSettings(timestamp);
            respo = someapp.Delete();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(!response.ToString().Contains(timestamp), "Member still exists in the list");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Delete patrol area"), Order(48)]
        public void DeletePatrolArea() 
        {

            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddPatrolAreaToSettings(timestamp);

            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Patrol area not found/ added to the list");

            someapp.DeletePatrolAreaFromSettings(timestamp);
            respo = someapp.Delete();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(!response.ToString().Contains(timestamp), "Patrol area still exists in the list");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Delete patrol hub"), Order(50)]
        public void DeletePatrolHub() 
        {

            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddPatrolHubToSettings(timestamp);

            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Patrol hub not found/ added to the list");

            someapp.DeletePatrolHubFromSettings(timestamp);
            respo = someapp.Delete();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(!response.ToString().Contains(timestamp), "Patrol hub still exists in the list");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }

        [TestCase(TestName = "Delete role"), Order(52)]
        public void DeleteRole() 
        {

            string timestamp = DateTime.Now.ToString("MMddyyyy_HHmmss");
            someapp.AddRoleToSettings(timestamp);

            var respo = someapp.Put();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");
            var response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(response.ToString().Contains(timestamp), "Patrol hub not found/ added to the list");

            someapp.DeleteRoleFromSettings(timestamp);
            respo = someapp.Delete();
            Assert.AreEqual(HttpStatusCode.OK, respo.status, "Status code is not 200");

            response = JsonConvert.DeserializeObject(respo.response);
            Assert.True(!response.ToString().Contains(timestamp), "Patrol hub still exists in the list");

            TestContext.WriteLine($"Response is {respo.response}");

            System.Threading.Thread.Sleep(1000);
        }




    }
}
