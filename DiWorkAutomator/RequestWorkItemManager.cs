using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiWorkAutomator
{
    internal class RequestWorkItemManager
    {
        public string ApiKey { get; private set; }
        public string Url { get; private set; }

        public RequestWorkItemManager(string apiKey, string url)
        {
            this.ApiKey = apiKey;
            this.Url = url;
        }

        public async Task<string> PostDailyWorkItem(string request)
        {
            return await PostWorkItem(request, "Task");
        }

        public async Task<string> PostDailyClientStory(string request)
        {
            return await PostWorkItem(request, "Client%20Story");
        }


        private async Task<string> PostWorkItem(string request, string typeWorkItem)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ContentType", "application/json-patch+json");

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(":" + ApiKey);
                string val = System.Convert.ToBase64String(plainTextBytes);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + val);



                var content = new StringContent(request, Encoding.UTF8, "application/json-patch+json");

                var response = await client.PostAsync(Url + typeWorkItem + "?api-version=7.0", content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}
