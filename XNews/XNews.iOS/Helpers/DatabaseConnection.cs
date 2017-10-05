using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XNews.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection))]
namespace XNews.iOS
{
    public class DatabaseConnection:IDatabaseConnection
    {
        public SQLiteConnection GetDbConnection()
        {
            var databaseName = "NewsDb.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, databaseName);
            return new SQLiteConnection(path);
        }
    }
}
