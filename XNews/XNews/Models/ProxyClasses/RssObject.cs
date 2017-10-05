using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XNews.Models.Data;

namespace XNews.Models.ProxyClasses
{
    public class Feed
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pubDate")]
        public string PubDate { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("enclosure")]
        public List<object> Enclosure { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        public News CopyToData()
        {
            News news = new News()
            {
                Author = this.Author,
                Content=this.Content,
                Description=this.Description,
                Guid=this.Guid,
                Link=this.Link,
                PubDate=this.PubDate,
                Thumbnail=this.Thumbnail,
                Title=this.Title
            };
            return news;
        }
    }

    public class RssObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("feed")]
        public Feed Feed { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
