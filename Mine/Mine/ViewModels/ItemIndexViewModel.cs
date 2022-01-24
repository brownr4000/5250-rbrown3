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
        public ObservableCollection<ItemModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The ItemIndexViewModel Constructor
        /// </summary>
        public ItemIndexViewModel()
        {
            Title = "Items";
            Items = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemCreatePage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                Items.Add(newItem);
                await DataStore.CreateAsync(newItem);
            });
        }

        /// <summary>
        /// The ExecuteLoadItemsComand performs actions when an item is loaded
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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
    }
}