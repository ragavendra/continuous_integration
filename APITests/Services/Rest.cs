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

    public interface IRestAction
    {
        //void BlobDownload(string connectionString, string blobName, string fileName, string filePath);
        //void BlobDownload(string connectionString, string blobName, string fileName, Stream stream);
        //void BlobUpload(string connectionString, string blobName, string fileName, string filePath);
        //void BlobUpload(string connectionString, string blobName, string fileName, Stream stream);

        (HttpStatusCode status, string response) Get();
        (HttpStatusCode status, string response) Post();
        (HttpStatusCode status, string response) Put();
        (HttpStatusCode status, string response) Delete();

        void Print();

        void Print_();

    }

    public interface IMessage
    {
        //void BlobDownload(string connectionString, string blobName, string fileName, string filePath);
        //void BlobDownload(string connectionString, string blobName, string fileName, Stream stream);
        //void BlobUpload(string connectionString, string blobName, string fileName, string filePath);
        //void BlobUpload(string connectionString, string blobName, string fileName, Stream stream);

        (HttpStatusCode status, string response) Get();
        (HttpStatusCode status, string response) Post();
        (HttpStatusCode status, string response) Put();
        (HttpStatusCode status, string response) Delete();


    }

    public class Rest : IRestAction
    {
        protected string URLi, sMessage;

        protected HttpClient client = new HttpClient();
        //protected JObject jMessage;

        public void Print()
        {
            TestContext.WriteLine("Print hey");
        }


        public void Print_()
        {
            TestContext.WriteLine("Print hey_");
        }


        public (HttpStatusCode status, string response) Get()
        {
            var asyncTask = httpGet();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpGet()
        {

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.GetAsync(URLi);

            //log performance
            logPerformance(startTimeAPI, "GET", ((int) response.StatusCode).ToString(), URLi);

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

        public (HttpStatusCode status, string response) Post()
        {
            var asyncTask = httpPost(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpPost(string request)
        {
            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PostAsync(URLi, content);

            //log performance
            logPerformance(startTimeAPI, "POST", ((int) response.StatusCode).ToString(), URLi);

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


        public (HttpStatusCode status, string response) Put()
        {
            var asyncTask = httpPut(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpPut(string request)
        {
            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.PutAsync(URLi, content);

            //log performance
            logPerformance(startTimeAPI, "PUT", ((int) response.StatusCode).ToString(), URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Delete()
        {
            var asyncTask = httpDelete();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        private async Task<(HttpStatusCode status, string response)> httpDelete()
        {

            // set headers
            SetDefaultHeaders();

            //get start time
            DateTime startTimeAPI = DateTime.Now;

            var response = await client.DeleteAsync(URLi);

            //log performance
            logPerformance(startTimeAPI, "DELETE", ((int) response.StatusCode).ToString(), URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

    }
}