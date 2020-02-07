using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestFluent
{

    public class RestFluentUsage
    {

        public void TestFixture()
        {
            var get = RestFluent.Connect("https://someserver/path/abc").Get();
            var post = RestFluent.Connect("https://someserver/path/abc").Post("key: abcd, value: efgh");

        }
    }

    public interface IRestActionWithMessage
    {
        Task <(HttpStatusCode status, string response)> Get();
        Task <(HttpStatusCode status, string response)> Delete();
        Task <(HttpStatusCode status, string response)> Post(string sMessage);
        Task <(HttpStatusCode status, string response)> Put(string sMessage);
    }

    public interface IMessage
    {
        IRestActionWithMessage Message(string sMessg);
    }

    public interface IUrli
    {
        IRestActionWithMessage Urli(string URLi);
    }

    public class RestFluent : IRestActionWithMessage, IUrli
    {
        private string URLi;

        protected HttpClient client = new HttpClient();
        private RestFluent(string URLi) => this.URLi = URLi;

        public static IRestActionWithMessage Connect(string URLi) => new RestFluent(URLi);

        public IRestActionWithMessage Urli(string URLi)
        {
            this.URLi = URLi;
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