using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using SQLite;
using Mine.Models;

namespace Mine.Services
{
    /// <summary>
    /// The Database Service class controls how the database interacts with the other pages
    /// </summary>
    public class DatabaseService : IDataStore<ItemModel> 
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
            InitializeAsync().SafeFireAndForget(false);
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

        /// <summary>
        /// The CreateAsync method adds and inserts ItemModel objects into the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if the item is added to the database</returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.InsertAsync(item);

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The UpdateAsync method takes and ItemModel object and updates its attributes
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True is the ItemModel was updated</returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.UpdateAsync(item);

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The DeleteAsync method removes an Item from the database
        /// </summary>
        /// <param name="id">The id of the ItemModel</param>
        /// <returns>True if the ItemModel is removed</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var data = await ReadAsync(id);

            // Checks if the Item exists for the given id
            if (data == null)
            {
                return false;
            }

            var result = await Database.DeleteAsync(data);

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The ReadAsync method takes and item ID and returns the ItemModel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The ItemModel being read</returns>
        public Task<ItemModel> ReadAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            // Call the Database to read the ID
            // Using Linq syntax, Find the first record that has the ID that matches
            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));

            return result;
        }

        /// <summary>
        /// The IndexAsync method displays the whole table from the database
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns>The result from the Database table</returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            var result = await Database.Table<ItemModel>().ToListAsync();
            return result;
        }
    }
}
