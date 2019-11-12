using AppName.Models;
using Newtonsoft.Json;

namespace AppName
{
    public class SomeApp : Rest
    {
        
        private string serverName = Constants.eotServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void GetAllSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/All";
        }

        public void GetCarsSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Cars";
        }

        public void GetMembersSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members";
        }

        public void GetPatrolAreasSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolAreas";
        }

        public void GetPatrolHubToSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolHubs";
        }

        public void GetPatrolRolesSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Roles";
        }

        public void GetShiftDefaultHoursSettings()
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/ShiftDefaultHours";
        }

        public void GetShiftsByDate(string date)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Shifts/{date}";
        }

        public void GetShiftsWithSettingsByDate(string date)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/ShiftsWithSettings/{date}";
        }

        //POST calls
        public void SaveMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members";

            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
            Member person = new Member();
            person.identification = identification;
            person.firstName = firstName;
            person.lastName = lastName;
            person.phone = phone;
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void UpdateShift(string name, string startHour, string endHour)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            sMessage = JsonConvert.SerializeObject(shift);
        }

        public void UpdateShiftDefaultHoursToSettings(string name, string startHour, string endHour)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            sMessage = JsonConvert.SerializeObject(shift);
        }

        //PUT calls
        public void AddMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members";

            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
            Member person = new Member();
            person.identification = identification;
            person.firstName = firstName;
            person.lastName = lastName;
            person.phone = phone;
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddCarToSettings(string car)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Cars/{car}";

            sMessage = JsonConvert.SerializeObject(car);
        }

        public void AddPatrolAreaToSettings(string area)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolAreas/{area}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddPatrolHubToSettings(string hub)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolHubs/{hub}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddRoleToSettings(string role)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Roles/{role}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddShift(string role)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Shifts/Add";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        //DELETE calls

        public void DeleteCarFromSettings(string car)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Cars/{car}";
        }

        public void DeleteMemberFromSettings(string identification)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Members/{identification}";
        }

        public void DeletePatrolAreaFromSettings(string area)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolAreas/{area}";
        }

        public void DeletePatrolHubFromSettings(string hub)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/PatrolHubs/{hub}";
        }

        public void DeleteRoleFromSettings(string role)
        {
            URLi = $"{protocol}://{serverName}/someapp/api/someapp/Settings/Roles/{role}";
        }


    }
}