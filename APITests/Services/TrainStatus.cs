
using System;

namespace PortalApp
{
    public class TrainStatus : Rest
    {
        
        private string serverName = Constants.portalServerName;
        private const string protocol = Constants.protocol;

        //GET calls
        public void GetTrainsStatuses()
        {
            URLi = $"{protocol}://{serverName}/trainstatus/api/TrainStatuses";
        }

        public void GetTrainStatus(string id = "")
        {
            if (id == "")
                URLi = $"{protocol}://{serverName}/trainstatus/api/Status";
            else
                URLi = $"{protocol}://{serverName}/trainstatus/api/Status?requestId={id}";
        }

        //2019-11-07T15:00:00Z
        public void GetTrainStatusHistory(DateTime dateTime)
        {
            URLi = $"{protocol}://{serverName}/trainstatus/api/TrainStatuses/History/{dateTime.ToString("yyyy-MM-ddTHH:mm:ss")}";
        }

        public void GetTrainStatusTimelapse(DateTime fromDateTime, DateTime toDateTime, int intervalInSeconds)
        {
            URLi = $"{protocol}://{serverName}/trainstatus/api/TrainStatuses/timelapse/{fromDateTime.ToString("yyyy-MM-ddTHH:mm:ss")}/{toDateTime.ToString("yyyy-MM-ddTHH:mm:ss")}/{intervalInSeconds.ToString()}";
        }


        //
        //        //POST calls
        //        public void CancelBus(string id, string firstName, string lastName, string phone)
        //        {
        //            URLi = $"{protocol}://{serverName}/BusCancellation/api/Values/{id}";
        //
        //            /*
        //            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
        //            Member person = new Member();
        //            person.identification = identification;
        //            person.firstName = firstName;
        //            person.lastName = lastName;
        //            person.phone = phone;
        //            sMessage = JsonConvert.SerializeObject(person);*/
        //        }
        //
        //        //PUT calls
        //        public void UpdateCancelBus(string id, string firstName, string lastName, string phone)
        //        {
        //            URLi = $"{protocol}://{serverName}/BusCancellation/api/Values/{id}";
        //
        //            /*
        //            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
        //            Member person = new Member();
        //            person.identification = identification;
        //            person.firstName = firstName;
        //            person.lastName = lastName;
        //            person.phone = phone;
        //            sMessage = JsonConvert.SerializeObject(person);*/
        //        }
        //
        //        //DELETE calls
        //        public void DeleteCancelBus(string id)
        //        {
        //            URLi = $"{protocol}://{serverName}/BusCancellation/api/Values/";
        //        }
        //
        //

    }
}
