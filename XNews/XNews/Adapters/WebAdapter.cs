using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XNews.Models.Data;
using XNews.Models.ProxyClasses;

namespace XNews.Adapters
{
    /// <summary>
    /// Contains methods for getting data from web
    /// </summary>
    public static class WebAdapter
    {

        private static string GetFullUriFromResources()
        {
            string result = String.Empty;
            result = XNews.Properties.Resources.UriRssConvert + Properties.Resources.UriNewsSource;
            return result;
        }

        public async static Task<RssObject> GetRssObjectAsync()
        {
            string json = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(GetFullUriFromResources());
                response.EnsureSuccessStatusCode();
                json = response.Content.ReadAsStringAsync().Result;
            }
            var rssObject = JsonConvert.DeserializeObject<RssObject>(json);
            return rssObject;
        }

        public async static Task<IEnumerable<News>> GetNewsAsync()
        {
            List<News> news = new List<News>();
            var rssObject = await WebAdapter.GetRssObjectAsync();
            foreach(var item in rssObject.Items)
            {
                news.Add(item.CopyToData());
            }
            return news;
        }
    }
}
