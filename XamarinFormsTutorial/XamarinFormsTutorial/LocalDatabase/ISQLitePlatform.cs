using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsTutorial.LocalDatabase
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetSQLiteConnection();

        SQLiteAsyncConnection GetSQLiteAsyncConnection();
    }
}
