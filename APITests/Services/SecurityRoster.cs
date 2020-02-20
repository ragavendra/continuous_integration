using System;
using System.Collections.Generic;
using PortalApp.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PortalApp
{
    public class SecurityRoster : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;
        private const string version = Constants.securityRosterVersion;

        //GET calls
        public void GetAllSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/All";
        }

        public void GetCarsSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Cars";
        }

        public void GetMembersSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members";
        }

        public void GetPatrolAreasSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolAreas";
        }

        public void GetPatrolHubToSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolHubs";
        }

        public void GetRolesSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Roles";
        }

        public void GetShiftDefaultHoursSettings()
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/ShiftDefaultHours";
        }

        public void GetShiftsByDate(string date)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Shifts?date={date}";
        }

        public void GetShiftsWithSettingsByDate(string date)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/ShiftsWithSettings/{date}";
        }

        //POST calls
        public void SaveMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members";

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
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            sMessage = JsonConvert.SerializeObject(shift);
        }

        public void UpdateShiftDefaultHoursToSettings(string name, string startHour, string endHour)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            sMessage = JsonConvert.SerializeObject(shift);
        }

        //PUT calls
        public void AddMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members";

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
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Cars/{car}";

            sMessage = JsonConvert.SerializeObject(car);
        }

        public void AddPatrolAreaToSettings(string area)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolAreas/{area}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddPatrolHubToSettings(string hub)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolHubs/{hub}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddRoleToSettings(string role)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Roles/{role}";

            Member person = new Member();
            sMessage = JsonConvert.SerializeObject(person);
        }

        public void AddShift(List<Member> mem, AddShift shift)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Shifts";
            sMessage = JsonConvert.SerializeObject(shift);
        }

        //DELETE calls

        public void DeleteCarFromSettings(string car)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Cars/{car}";
        }

        public void DeleteMemberFromSettings(string identification)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Members/{identification}";
        }

        public void DeletePatrolAreaFromSettings(string area)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolAreas/{area}";
        }

        public void DeletePatrolHubFromSettings(string hub)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/PatrolHubs/{hub}";
        }

        public void DeleteRoleFromSettings(string role)
        {
            URLi = $"{protocol}://{serverName}/securityroster/api/v{version}/SecurityRoster/Settings/Roles/{role}";
        }


    }
}