using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mine.Services;
using Mine.Views;

namespace Mine
{
    /// <summary>
    /// The App class defines the stucture for the whole app
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The App constructor defines components that run at startup
        /// </summary>
        public App()
        {
            // Call InitializeComponent method
            InitializeComponent();

            // Define the DependencyService to access the ItemModel data
            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<DatabaseService>();
            
            // Set the Main Page to a new Main Page
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
