using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Searchfight.Common.Constants;

namespace Searchfight.Service
{
    public class HtmlScrapperService
    {
        private HttpClient httpClient;

        public HtmlScrapperService() : this(USER_AGENT_CHROME)
        {
        }

        public HtmlScrapperService(string userAgent)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = false;
            httpClientHandler.Proxy = null;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(HTTP_HEADER_USER_AGENT, userAgent);
        }
        public async Task<string> Scrap(string address, Dictionary<string, string> queryParams)
        {
            string url = buildUrl(address, queryParams);
            string response = await httpClient.GetStringAsync(url);
            return response;
        }

        private string buildUrl (string url, Dictionary<string, string> queryParams) {
            StringBuilder parametersBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in queryParams)
            {
                parametersBuilder.Append($"{pair.Key}={pair.Value}&");
            }
            return string.Format("{0}?{1}", url, parametersBuilder.ToString());
        }
    }
}
