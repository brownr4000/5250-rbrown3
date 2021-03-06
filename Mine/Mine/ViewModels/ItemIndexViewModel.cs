using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mine.Models;
using Mine.Views;

namespace Mine.ViewModels
{
    /// <summary>
    /// The ItemIndexViewModel defines the ItemView, and is an extension of the BaseViewModel
    /// </summary>
    public class ItemIndexViewModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> DataSet { get; set; }

        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The ItemIndexViewModel Constructor
        /// </summary>
        public ItemIndexViewModel()
        {
            Title = "Items";
            DataSet = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Looking for an "AddItem" message
            MessagingCenter.Subscribe<ItemCreatePage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                DataSet.Add(newItem);
                await DataStore.CreateAsync(newItem);
            });

            // Looking for an "DeleteItem" message
            MessagingCenter.Subscribe<ItemDeletePage, ItemModel>(this, "DeleteItem", async (obj, item) =>
            {
                var data = item as ItemModel;
                
                await DeleteAsync(data);
            });

            // Looking for an "UpdateItem" message
            MessagingCenter.Subscribe<ItemUpdatePage, ItemModel>(this, "UpdateItem", async (obj, item) =>
            {
                var data = item as ItemModel;

                await UpdateAsync(data);
            });
        }

        /// <summary>
        /// The ExecuteLoadItemsComand performs actions when an item is loaded
        /// </summary>
        /// <returns>Empty</returns>
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DataSet.Clear();
                var items = await DataStore.IndexAsync(true);
                foreach (var item in items)
                {
                    DataSet.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// The ReadAsync method reads an item from the datastore
        /// </summary>
        /// <param name="id">THe ID of the reccord</param>
        /// <returns>The Record from ReadAsync</returns>
        public async Task<ItemModel> ReadAsync(string id)
        {
            var result = await DataStore.ReadAsync(id);

            return result;
        }

        /// <summary>
        /// The DeleteAsync method deletes a record from the system
        /// </summary>
        /// <param name="data">The Record to Delete</param>
        /// <returns>True if Deleted</returns>
        public async Task<bool> DeleteAsync (ItemModel data)
        {
            // Get record
            var record = await ReadAsync(data.Id);

            // Check if record exists, if it does not, then null is returned
            if (record == null)
            {
                return false;
            }

            // Remove from the local data set cache
            DataSet.Remove(data);

            // Call to remove it from the Data Store
            var result = await DataStore.DeleteAsync(data.Id);

            return result;
        }

        /// <summary>
        /// The UpdateAsync method updates the record from the system
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(ItemModel data)
        {
            // Get record
            var record = await ReadAsync(data.Id);

            // Check if record exists, if it does not, then null is returned
            if (record == null)
            {
                return false;
            }

            // Call to remove it from the Data Store
            var result = await DataStore.UpdateAsync(data);

            var canExecute = LoadItemsCommand.CanExecute(null);
            LoadItemsCommand.Execute(null);

            return result;
        }
    }
}