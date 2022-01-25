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
    }
}