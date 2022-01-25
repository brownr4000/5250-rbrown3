using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;

namespace Mine.Views
{
    /// <summary>
    /// The ItemUpdatePage class provides the framework to update item objects
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemUpdatePage : ContentPage
    {
        // The ItemModel Item method
        public ItemModel Item { get; set; }

        /// <summary>
        /// The ItemUpdatePage Constructor
        /// </summary>
        public ItemUpdatePage()
        {
            InitializeComponent();

            Item = new ItemModel
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        /// <summary>
        /// The Save_Clicked method defines the action when save button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// The Cancel_Clicked method defines the action when the cancel button is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// The Value_OnStepperValueChanged method updates the Display Value when the Stepper changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Storing Value to the Item object
            ValueValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}