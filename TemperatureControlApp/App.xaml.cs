using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TemperatureControlApp.Data;
using TemperatureControlApp.Services;
using TemperatureControlApp.Views;

namespace TemperatureControlApp
{
    public partial class App : Application
    {
        static DataBase database;
        public static DataBase Database
        {
            get
            {
                if (database == null) database = new DataBase();
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
