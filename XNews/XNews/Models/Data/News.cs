using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XNews.Models.Data
{
    [Table("News")]
    public class News
    {
        [PrimaryKey, AutoIncrement]
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string PubDate { get; set; }

        public string Link { get; set; }

        public string Guid { get; set; }

        public string Author { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        //public List<object> Enclosure { get; set; }

        //public List<string> Categories { get; set; }
    }
}
