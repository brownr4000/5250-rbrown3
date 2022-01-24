using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mine.Views
{
    /// <summary>
    /// The AboutPage class defines the code behind for the display of the AboutPage
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        /// <summary>
        /// The AboutPage Constructor
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();

            // Defining Text of CurrentDateTimeLabel in corresponding XAML page
            CurrentDateTimeLabel.Text = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}