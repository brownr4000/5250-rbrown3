using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views
{
    /// <summary>
    /// The ItemDeletePage class defines the code behind for the IteReadPage xaml
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemDeletePage : ContentPage
    {
        ItemReadViewModel viewModel;

        /// <summary>
        /// The ItemDeletePage Constructor takes an ItemDetailViewModel object and displays it on the ItemReadPage
        /// </summary>
        /// <param name="viewModel">The viewMode to display</param>
        public ItemDeletePage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        /// <summary>
        /// The ItemDeletePage Default Constructor
        /// </summary>
        public ItemDeletePage()
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
        /// The DeleteItem_Clicked method deletes the iteon on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            // Displays message to screen
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);

            // Pops the current page from the Nagivation stack
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// The CancelItem_Clicked method cancels the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CancelItem_Clicked(object sender, EventArgs e)
        {
            // Pops the current page from the Nagivation stack
            await Navigation.PopModalAsync();
        }
    }
}