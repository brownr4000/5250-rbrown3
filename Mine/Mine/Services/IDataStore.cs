using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mine.Services
{
    /// <summary>
    /// The IDataStore public interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        // The CreateAsync method
        Task<bool> CreateAsync(T item);

        // The UpdateItemAsync mewthod
        Task<bool> UpdateItemAsync(T item);
        
        // The DeleteItemAsync method
        Task<bool> DeleteItemAsync(string id);

        // The ReadAsync method
        Task<T> ReadAsync(string id);

        // The GetItemsAsync method
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
