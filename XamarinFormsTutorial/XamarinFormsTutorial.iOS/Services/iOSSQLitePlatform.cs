using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using XamarinFormsTutorial.Config;
using XamarinFormsTutorial.iOS.Services;
using XamarinFormsTutorial.LocalDatabase;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSQLitePlatform))]
namespace XamarinFormsTutorial.iOS.Services
{
    class iOSSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var stringLibrary = Path.Combine(personalFolder, "..", "Library");
            return Path.Combine(stringLibrary, Constants.DatabaseName);
        }
        public SQLiteAsyncConnection GetSQLiteAsyncConnection()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        public SQLiteConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(GetPath());
        }
    }
}