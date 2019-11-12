using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace AppName
{

    public class Rest
    {
        protected string URLi, sMessage, auth;
        //protected JObject jMessage;

        public (HttpStatusCode status, string response) Get()
        {
            var asyncTask = httpGet();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        public async Task<(HttpStatusCode status, string response)> httpGet()
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.GetAsync(URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }


        public (HttpStatusCode status, string response) Post()
        {
            var asyncTask = httpPost(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        public async Task<(HttpStatusCode status, string response)> httpPost(string request)
        {
            var client = new HttpClient();
            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PostAsync(URLi, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Put()
        {
            var asyncTask = httpPut(sMessage);
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        public async Task<(HttpStatusCode status, string response)> httpPut(string request)
        {
            var client = new HttpClient();
            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.PutAsync(URLi, content);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        public (HttpStatusCode status, string response) Delete()
        {
            var asyncTask = httpDelete();
            asyncTask.Wait();
            return (asyncTask.Result.status, asyncTask.Result.response);
        }

        public async Task<(HttpStatusCode status, string response)> httpDelete()
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            var response = await client.DeleteAsync(URLi);

            return (response.StatusCode, await response.Content.ReadAsStringAsync());
        }


        public string performGetOpn()
        {
            var jsonResponse = "";
            Task<string> asyncTask;

            try
            {
                asyncTask = GetAsync();
                asyncTask.Wait();
                jsonResponse = asyncTask.Result;
                //jsonResponse = httpGet();
            }
            catch (AggregateException e)
            {
                Debug.WriteLine("Aggregation Exception is {0} ", e.Message);
                asyncTask = GetAsync();
                asyncTask.Wait();
                jsonResponse = asyncTask.Result;
                //jsonResponse = httpGet();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception is {0} ", e.Message);
                return "";
            }

            return jsonResponse;
        }

        public async Task<string> GetAsync()
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Subscription-Key", Constants.apiKey);

            try
            {
                response = await httpClient.GetAsync(URLi);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception is {0} ", e.Message);
                System.Threading.Thread.Sleep(1000);
                response = await httpClient.GetAsync(URLi);
            }

            //will throw an exception if not successful
            //response.EnsureSuccessStatusCode();
            if (response.StatusCode == HttpStatusCode.BadGateway)
                response = await httpClient.GetAsync(URLi);

            string content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => content);

        }

        public string performPostOpn(JObject request)
        {

            var client = new HttpClient();
            var jsonResponse = "";
            HttpResponseMessage response = null;

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            //if (bJsonResponse)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                if (auth != "")
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
                //client.DefaultRequestHeaders.Add("Authorization", "Basic cm91dGVyc2VydmljZWNsaWVudGluOjlhZG1MNXk2eHpBd2F0TlI3WDVz");
                //client.DefaultRequestHeaders.Add("Authorization", "Basic 38e1133ef1dfa56e57dfb515255af66f38df970ad03e21184a87a102c51e5b6e");
                //client.DefaultRequestHeaders.Authorization = "";
            }

            // Create a request using a URL that can receive a post. 
            WebRequest reques = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            // Set the Method property of the request to POST.
            reques.Method = "POST";

            var task = client.PostAsync(URLi, content)
                .ContinueWith((taskwithresponse) =>
                {
                    response = taskwithresponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    //response.EnsureSuccessStatusCode();
                    //response.StatusCode;

                    jsonString.Wait();
                    jsonResponse = jsonString.Result;
                });
            task.Wait();

            TestContext.WriteLine("Status code - {0} ", response.StatusCode);

            return jsonResponse;
        }

        public async Task<string> PostAsync(string uri, string data)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(data));

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            //return await Task.Run(() => JsonObject.Parse(content));
            return await Task.Run(() => content);
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



    }


}