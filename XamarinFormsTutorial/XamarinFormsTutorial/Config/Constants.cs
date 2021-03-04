

using System;
using System.IO;

namespace XamarinFormsTutorial.Config
{
    public class Constants
    {
        public const string DatabaseName = "sqlite_db.db3";

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseName);
            }
        }
    }
}
