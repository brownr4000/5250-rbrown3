using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.Views;
using Mine.ViewModels;

namespace Mine.Views
{
    /// <summary>
    /// The ItemIndexPage class provides the framework to display items in a list view on the screen
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemIndexPage : ContentPage
    {
        ItemIndexViewModel viewModel;

        /// <summary>
        /// The ItemIndexPage Constructor
        /// </summary>
        public ItemIndexPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemIndexViewModel();
        }

        /// <summary>
        /// The OnItemSelected method defines what happens when an item is selected on the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ItemModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemReadPage(new ItemReadViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        /// <summary>
        /// The AddItem_Clicked method defines what happnes when the AddItem button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemCreatePage()));
        }

        /// <summary>
        /// THe OnAppearing override method
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}