using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using XNews.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection))]
namespace XNews.Droid
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection GetDbConnection()
        {
            var databaseName = "NewsDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseName);
            return new SQLiteConnection(path);
        }
    }
}