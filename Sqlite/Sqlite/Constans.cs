using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sqlite
{
    public static class Constans
    {
        private const string DatabaseFilename = "SQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;




        public static string DatabasePath
        {
            get
            {
                var basPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basPath, DatabaseFilename);
            }
        }
    }
}
