using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PortalApp
{

    public class ResFluent
    {

        public void TestFixture()
        {
            //FluentBlobTransfer flue;
            //FluentBlobTransfer.Connect("").

            //RestFluent.Urli("").
            //RestFluent.
            //RestFluent.


        }
    }


    public interface IRestActionWithMessage
    {
        Task <(HttpStatusCode status, string response)> Post();
        Task <(HttpStatusCode status, string response)> Put();
    }

    public interface IRestActionWithoutMessage
    {
        Task <(HttpStatusCode status, string response)> Get();
        Task <(HttpStatusCode status, string response)> Delete();
    }

    public interface IMessage
    {
        IRestActionWithMessage Message(string sMessg);
    }

    public interface IUrli
    {
        IRestActionWithMessage Urli(string URLi);
    }

    public class RestFluent : IRestActionWithMessage, IRestActionWithoutMessage, IMessage, IUrli
    {
        private string URLi, sMessage;

        protected HttpClient client = new HttpClient();
        private RestFluent(string URLi) => this.URLi = URLi;

        public static IRestActionWithMessage Connect(string URLi) => new RestFluent(URLi);

        public IRestActionWithMessage Urli(string URLi)
        {
            this.URLi = URLi;

            return this;
        }

        public IRestActionWithMessage Message(string sMessg)
        {
            this.sMessage = sMessg;
            return this;
        }

        public async Task<(HttpStatusCode status, string response)> Get()
        {
            //var asyncTask = httpGet();

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.GetAsync(URLi);

            //log performance
            logPerformance(startTimeAPI, "GET", ((int) response.StatusCode).ToString(), URLi);

            //return (response.StatusCode, await response.Content.ReadAsStringAsync());
            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        private void logPerformance(DateTime startTimeAPI, string callType, string status, string url)
        {

            string responseTime = (DateTime.Now - startTimeAPI).TotalMilliseconds.ToString();
            logPerfToFile(responseTime, callType, status, url);

            //TestContext.WriteLine($"Endpoint - {url}");
            TestContext.WriteLine("Response time - {0} ms", responseTime);

        }

        //logs performance to csv
        private async void logPerfToFile(string time, string callType, string status, string url)
        {

            if (System.IO.File.Exists(Constants.perfLog))
                using (StreamWriter streamWriter = System.IO.File.AppendText(Constants.perfLog))
                    await streamWriter.WriteLineAsync($"{time}, {callType}, {status}, {url}");
            else
                using (StreamWriter streamWriter = System.IO.File.CreateText(Constants.perfLog))
                    await streamWriter.WriteLineAsync($"{time}, {callType}, {status}, {url}");
        }

        public async Task<(HttpStatusCode status, string response)> Post()
        {
            var content = new StringContent(sMessage.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PostAsync(URLi, content);

            //log performance
            logPerformance(startTimeAPI, "POST", ((int) response.StatusCode).ToString(), URLi);

            //return (response.StatusCode, await response.Content.ReadAsStringAsync());

            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        protected void SetDefaultHeaders()
        {
            if (!client.DefaultRequestHeaders.Contains("TL-Apim-Subscription-Key"))
                // Request headers
                client.DefaultRequestHeaders.Add("TL-Apim-Subscription-Key", Constants.apiKey);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }


        public void SetCustomHeader(string key, string value)
        {
            // Request headers
            client.DefaultRequestHeaders.Add(key, value);
        }


        public async Task<(HttpStatusCode status, string response)> Put()
        {

            var content = new StringContent(sMessage.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PutAsync(URLi, content);

            //log performance
            logPerformance(startTimeAPI, "PUT", ((int) response.StatusCode).ToString(), URLi);

            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public async Task<(HttpStatusCode status, string response)> Delete()
        {

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.DeleteAsync(URLi);

            //log performance
            logPerformance(startTimeAPI, "DELETE", ((int) response.StatusCode).ToString(), URLi);

            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

    }
}