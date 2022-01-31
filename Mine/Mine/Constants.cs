using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mine
{
    /// <summary>
    /// The Constants Class defines the interface to the SQLite database
    /// </summary>
    public static class Constants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =

            // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |

            // Create the database if it does not exist
            SQLite.SQLiteOpenFlags.Create |

            // Enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        // The DatabasePath stores the filepath to the local database file
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
