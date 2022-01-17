using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Equinox Gem", Description="A rare gemstone that contains healing properties.", Value=2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Iron Greatboots", Description="Tall boots made of Iron plate, with a moderate heel.", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Standard Thermal Zapper", Description="Fancy words for a heat gun or hair dryer.", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Queller of the Night Sky", Description="A gigantic laser cannon of alien design.", Value=6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Tonic of Invisibility", Description="A greyish liquid that grants invisibility for 30 minutes.", Value=3 }
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}