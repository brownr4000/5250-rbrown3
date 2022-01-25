using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views
{
    /// <summary>
    /// The ItemReadPage class defines the code behind for the IteReadPage xaml
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemReadPage : ContentPage
    {
        ItemReadViewModel viewModel;

        /// <summary>
        /// The ItemReadPage Constructor takes an ItemDetailViewModel object and displays it on the ItemReadPage
        /// </summary>
        /// <param name="viewModel"></param>
        public ItemReadPage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        /// <summary>
        /// The ItemReadPage Default Constructor
        /// </summary>
        public ItemReadPage()
        {
            InitializeComponent();

            var item = new ItemModel
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemReadViewModel(item);
            BindingContext = viewModel;
        }

        /// <summary>
        /// The DeleteItem_Clicked method opens the Delete item page for the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(viewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// The UpdateItem_Clicked method opens the Update item page for the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void UpdateItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(viewModel)));
            await Navigation.PopAsync();
        }
    }
}