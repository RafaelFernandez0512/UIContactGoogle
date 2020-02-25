using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UIContactsApp.Services
{
    public static class ConstantDB
    {
        public const string _dataBaseNameFile = "ContactSqlLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
         SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, _dataBaseNameFile);
            }
        }
    }
}
