using System;
using System.Linq;
using System.Threading.Tasks;

using SQLite;
using Mine.Models;

namespace Mine.Services
{
    /// <summary>
    /// The Database Service class
    /// </summary>
    public class DatabaseService
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        // Variables to initialize database
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitalizeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }

                initialized = true;
            }
        }
    }
}
