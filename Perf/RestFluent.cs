using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PortalApp;

namespace RestFluent
{

    public class RestFluentUsage : TestFixture
    {
        [TestCase(TestName = "CIR List fluent"), Order(0)]
        public void TestFixture()
        {
            Hashtable sKeyValue = new Hashtable();
            sKeyValue.Add("TL-Apim-Subscription-Key", "40635b3b66c34ae0942c0667ff5899b3");
            //sKeyValue.Add("Content-Type", "application/json");

            var get = RestFluent.Connect("https://translink-dev.azure-api.net/securityroster/api/v1/SecurityRoster/Settings/Cars").Header(sKeyValue).Get();
            //var post = RestFluent.Connect("https://translink-dev.azure-api.net/cirlist/api/v1/CirList/cirsfromDate=2019-12-27&toDate=2019-12-29").Header(sKeyValue).Post("key: abcd, value: efgh");

            //var get1 = RestFluent.Connect("https://someserver/path/abc").
            Assert.AreEqual(200, (int) get.Result.status, "Status code is not 200");
            //Assert.AreEqual(200, get.Result.response, "Status code is not 200");

        }
    }

    public interface IRestActionWithMessage
    {
        Task <(HttpStatusCode status, string response)> Get();
        Task <(HttpStatusCode status, string response)> Delete();
        Task <(HttpStatusCode status, string response)> Post(string sMessage);
        Task <(HttpStatusCode status, string response)> Put(string sMessage);
    }

    public interface IHeaderData
    {
        IRestActionWithMessage Header(Hashtable sKeyValue);
    }

    public interface IUrli
    {
        IRestActionWithMessage Urli(string URLi);
    }

    public class RestFluent : IRestActionWithMessage, IUrli, IHeaderData
    {
        private string URLi;

        protected HttpClient client = new HttpClient();
        private RestFluent(string URLi) => this.URLi = URLi;

        public static IHeaderData Connect(string URLi) => new RestFluent(URLi);

        public IRestActionWithMessage Urli(string URLi)
        {
            this.URLi = URLi;
            return this;
        }

        public IRestActionWithMessage Header(Hashtable sKeyValue)
        {
            //this.client = client;

            foreach (var key in sKeyValue.Keys)
            {
                if (!this.client.DefaultRequestHeaders.Contains(key.ToString()))
                    // Request headers
                    this.client.DefaultRequestHeaders.Add(key.ToString(), "40635b3b66c34ae0942c0667ff5899b3");
            }

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

            //return (response.StatusCode, await response.Content.ReadAsStringAsync());
            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public async Task<(HttpStatusCode status, string response)> Post(string sMessage)
        {
            var content = new StringContent(sMessage.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PostAsync(URLi, content);

            //return (response.StatusCode, await response.Content.ReadAsStringAsync());

            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        protected void SetDefaultHeaders()
        {
            if (!client.DefaultRequestHeaders.Contains("ApiKey"))
                // Request headers
                client.DefaultRequestHeaders.Add("ApiKey", "ApiKeyValue");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public void SetCustomHeader(string key, string value)
        {
            // Request headers
            client.DefaultRequestHeaders.Add(key, value);
        }

        public async Task<(HttpStatusCode status, string response)> Put(string sMessage)
        {

            var content = new StringContent(sMessage.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PutAsync(URLi, content);

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

            var asyncTask = response.Content.ReadAsStringAsync();
            asyncTask.Wait();
            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

    }
}