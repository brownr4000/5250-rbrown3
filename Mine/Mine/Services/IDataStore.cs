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

        // The UpdateAsync mewthod
        Task<bool> UpdateAsync(T item);
        
        // The DeleteAsync method
        Task<bool> DeleteAsync(string id);

        // The ReadAsync method
        Task<T> ReadAsync(string id);

        // The IndexAsync method
        Task<IEnumerable<T>> IndexAsync(bool forceRefresh = false);
    }
}
