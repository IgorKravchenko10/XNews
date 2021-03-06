﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNews.Models.Data;

namespace XNews.Adapters
{
    /// <summary>
    /// Contains methods for database interaction
    /// </summary>
    public static class DbAdapter
    {
        private static object _collisionLock = new object();

        public async static Task<IEnumerable<News>> GetNewsAsync(DbContext dbContext)
        {
            IEnumerable<News> news = await Task.Factory.StartNew(() =>
            {
                lock (_collisionLock)
                {
                    return dbContext.Database.Table<News>().ToList();
                }
            });
            return news;
        }

        public static IEnumerable<News> GetNewsSql(DbContext dbContext)
        {
            lock (_collisionLock)
            {
                return dbContext.Database.Query<News>("SELECT * FROM News").AsEnumerable();
            }
        }

        public static int SyncNews(DbContext dbContext, IEnumerable<News> newsList)
        {
            lock (_collisionLock)
            {
                dbContext.Database.DeleteAll<News>();
                return dbContext.Database.InsertAll(newsList);
            }
        }
    }
}
