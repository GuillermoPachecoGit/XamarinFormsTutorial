using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XamarinFormsTutorial.Config;
using XamarinFormsTutorial.Droid.Services;
using XamarinFormsTutorial.LocalDatabase;


[assembly: Xamarin.Forms.Dependency(typeof(AndroidSqlitePlatform))]
namespace XamarinFormsTutorial.Droid.Services
{
    class AndroidSqlitePlatform : ISQLitePlatform
    {

        private string GetPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constants.DatabaseName);
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