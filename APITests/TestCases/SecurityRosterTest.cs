using System;
using System.Collections.Generic;
using System.Net;
using PortalApp.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace PortalApp
{
    public class SecurityRosterTest : TestFixture
    {

        [TestCase(TestName = "Invalid auth key"), Order(54)]
        public void InvalidAuthKey() 
        {
            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetAllSettings();
            securityRoster.SetCustomHeader("TL-Apim-Subscription-Key", "wrongKey");
            var respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetCarsSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetPatrolAreasSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetMembersSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetRolesSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetPatrolHubToSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetShiftDefaultHoursSettings();
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            string timestamp = Constants.now.AddDays(1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            securityRoster.GetShiftsByDate(timestamp);
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

            //get
            securityRoster.GetShiftsWithSettingsByDate(timestamp);
            respo = securityRoster.Get();
            TestContext.WriteLine($"Response is {respo.response}");
            Assert.AreEqual(401, (int) respo.status, "Status code is not 401");

        }

        [TestCase(TestName = "Member settings workflow"), Order(56)]
        public void MemberSettingsWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetMembersSettings();
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            var members = JsonConvert.DeserializeObject<List<Member>>(respo.response);
            //JObject resp = JObject.Parse(respo.response);

            //check if member already exists in the system
            foreach (var member in members)
                Assert.AreNotEqual(memberId, member.identification, $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            //securityRoster.AddMemberToSettings(memberId, "First", "Last", "604 111 1111");
            securityRoster.SaveMemberToSettings(memberId, "First", "Last", "604 111 1111");
            respo = securityRoster.Post();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var member = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            securityRoster.GetMembersSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            members = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            bool flag = false;

            //check if member exists in the system
            foreach (var member in members)
            {
                if (member.identification == null)
                    continue;
                if (member.identification.Equals(memberId))
                {
                    flag = true;
                    break;
                }
            }

            Assert.True(flag, $"Member id - {memberId} does not exist in the system after POST");

            //delete member
            securityRoster.DeleteMemberFromSettings(memberId);
            respo = securityRoster.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");


            securityRoster.GetMembersSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            members = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            flag = false;

            //check if member does not exists in the system
            foreach (var member in members)
            {
                if (member.identification == null)
                    continue;
                if (member.identification.Equals(memberId))
                {
                    flag = true;
                    break;
                }
            }

            Assert.True(!flag, $"Member id - {memberId} exists in the system after DELETE");


        }

        [TestCase(TestName = "Role settings workflow"), Order(60)]
        public void RoleSettingsWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetRolesSettings();
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            string resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            securityRoster.AddRoleToSettings(memberId);
            respo = securityRoster.Put();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetRolesSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            resp = respo.response;

            Assert.True(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //delete member
            securityRoster.DeleteRoleFromSettings(memberId);
            respo = securityRoster.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetRolesSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

        }

        [TestCase(TestName = "Car settings workflow"), Order(62)]
        public void CarSettingsWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetCarsSettings();
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            string resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            securityRoster.AddCarToSettings(memberId);
            respo = securityRoster.Put();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var member = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            securityRoster.GetCarsSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            resp = respo.response;

            Assert.True(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //delete member
            securityRoster.DeleteCarFromSettings(memberId);
            respo = securityRoster.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetCarsSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

        }

        [TestCase(TestName = "Patrol area workflow"), Order(64)]
        public void PatrolAreaWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetPatrolAreasSettings();
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var members = JsonConvert.DeserializeObject<Array>(respo.response);
            //JObject resp = JObject.Parse(respo.response);
            string resp = respo.response;

            //check if member already exists in the system
       //     foreach (var member in members)
       //         Assert.AreNotEqual(memberId, member, $"Member id - {memberId} exists in the system");

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            securityRoster.AddPatrolAreaToSettings(memberId);
            respo = securityRoster.Put();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetPatrolAreasSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            resp = respo.response;

            Assert.True(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //delete member
            securityRoster.DeletePatrolAreaFromSettings(memberId);
            respo = securityRoster.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetPatrolAreasSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

        }

        [TestCase(TestName = "Patrol hub workflow"), Order(66)]
        public void PatrolHubWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SecurityRoster securityRoster = new SecurityRoster();

            securityRoster.GetPatrolHubToSettings();
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            string resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            securityRoster.AddPatrolHubToSettings(memberId);
            respo = securityRoster.Put();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var member = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            securityRoster.GetPatrolHubToSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            resp = respo.response;
            //members = JsonConvert.DeserializeObject<Array>(respo.response);

            Assert.True(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

            //delete member
            securityRoster.DeletePatrolHubFromSettings(memberId);
            respo = securityRoster.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            securityRoster.GetPatrolHubToSettings();
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            resp = respo.response;

            Assert.False(resp.ToString().Contains(memberId), $"Member id - {memberId} exists in the system");

        }

        [TestCase(TestName = "Shifts workflow"), Order(68)]
        public void ShiftsWorkflow()
        {
            SecurityRoster securityRoster = new SecurityRoster();

            DateTime memberId = DateTime.Today.AddDays(3);

            securityRoster.GetShiftsByDate(memberId.ToString("yyyy-MM-dd"));
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            string resp = respo.response;

            //add member to the system - use POST call
            List<Member> mem = new List<Member>();
            mem.Add(new Member());
            mem[0].hhu = "000";
            //mem[0].identification = memberId.ToString("11212019_151650");
            mem[0].identification = "11212019_151650";
            mem[0].firstName = "First";
            mem[0].lastName = "Last";
            mem[0].phone = "604 111 1111";

            AddShift shift = new AddShift();
            //shift.shiftDate = Constants.now.AddDays(3).ToString("yyyy-MM-ddT00:00:00");
            shift.car = "123";
            //shift.shiftDate = Constants.now.AddDays(3);
            shift.shiftDate = memberId.ToString("yyyy-MM-ddT00:00:00");
            shift.role = "Bike Patrol Officer";
            shift.shiftStartHour = "0730";
            shift.shiftEndHour = "1315";
            shift.shiftType = "Day";
            shift.docType = "Shift";

            Patrol patrol = new Patrol();
            List<string> lis = new List<string>();

            shift.patrol = patrol;
            shift.patrol.hubs = lis;
            shift.patrol.areas = lis;

            shift.createdTs = Constants.now.AddDays(10).ToString("yyyy-MM-ddTHH:mm:ss");
            shift.modifiedTs = Constants.now.AddDays(10).AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ss");

            shift.members = mem;

            shift.comments = "adding shift for ";// + timestamp.ToString("yyyy-MM-ddT00:00:00");
            shift.createdBy = "Eric.Kinskofer@translink.ca";
            shift.modifiedBy = "Eric.Kinskofer@translink.ca";

            securityRoster.AddShift(mem, shift);
            respo = securityRoster.Post();
            Assert.AreEqual(200, (int) respo.status, $"Status code is not 200 {respo.response}");

            securityRoster.GetShiftsByDate(memberId.ToString("yyyy-MM-dd"));
            respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            resp = respo.response;

            Assert.True(resp.Contains(mem[0].identification), $"Member id - {memberId} does not exists in the system");

        }

        [TestCase(TestName = "Add shift errors"),TestCaseSource(typeof(Data), "SecurityErrors"), Order(70)]
        public void AddShiftValidation(string car, string role, string startHour, string endHour, string message)
        {

            SecurityRoster securityRoster = new SecurityRoster();

            //string memberId = Constants.now.AddDays(1).AddHours(3).ToString("yyyy-MM-ddTHH:mm:ssZ");
            DateTime memberId = DateTime.Today.AddDays(3);

            securityRoster.GetShiftsByDate(memberId.ToString("yyyy-MM-dd"));
            var respo = securityRoster.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            string resp = respo.response;

            List<Member> mem = new List<Member>();
            mem.Add(new Member());
            mem[0].hhu = "000";
            //mem[0].identification = memberId.ToString("11212019_151650");
            mem[0].identification = "11212019_151650";
            mem[0].firstName = "First";
            mem[0].lastName = "Last";
            mem[0].phone = "604 111 1111";


            AddShift shift = new AddShift();
            //shift.shiftDate = Constants.now.AddDays(3).ToString("yyyy-MM-ddT00:00:00");
            shift.car = car;
            //shift.shiftDate = Constants.now.AddDays(3);
            shift.shiftDate = memberId.ToString("yyyy-MM-ddT00:00:00");
            shift.role = role;
            shift.shiftStartHour = startHour;
            shift.shiftEndHour = endHour;
            //shift.shiftStartHour = "0730";
            //shift.shiftEndHour = "1315";
            shift.shiftType = "Day";
            shift.docType = "Shift";

            Patrol patrol = new Patrol();

            List<string> lis = new List<string>();

            shift.patrol = patrol;
            shift.patrol.hubs = lis;
            shift.patrol.areas = lis;
            shift.createdTs = Constants.now.AddDays(10).ToString("yyyy-MM-ddTHH:mm:ss");
            shift.modifiedTs = Constants.now.AddDays(10).AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ss");
            shift.members = mem;
            shift.comments = "adding shift for ";// + timestamp.ToString("yyyy-MM-ddT00:00:00");
            shift.createdBy = "Eric.Kinskofer@translink.ca";
            shift.modifiedBy = "Eric.Kinskofer@translink.ca";

            securityRoster.AddShift(mem, shift);
            respo = securityRoster.Post();
            Assert.AreEqual(400, (int) respo.status, $"Status code is not 400 {respo.response}");
            var error = JsonConvert.DeserializeObject<SecurityError>(respo.response);
            Assert.AreEqual(message, error.detail, "Error detail is not valid");

        }

    }
}
