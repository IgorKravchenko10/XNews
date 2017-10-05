using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XNews.Models.Data;
using System.Collections.ObjectModel;
using XNews.Adapters;

namespace XNews
{
    public class DbContext
    {
        public SQLiteConnection Database
        {
            get
            {
                return DependencyService.Get<IDatabaseConnection>().GetDbConnection();
            }
        }

        public DbContext()
        {
            this.Database.CreateTable<News>();
        }

        /// <summary>
        /// Download new data from Internet and delete old data
        /// </summary>
        public async Task SyncDataWithWeb()
        {
            var newsFromWeb = await WebAdapter.GetNewsAsync();
            DbAdapter.SyncNews(this, newsFromWeb);
        }
    }
}
