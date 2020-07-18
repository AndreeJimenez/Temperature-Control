using System;
using TemperatureControlApp.Models;
using TemperatureControlApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemperatureControlApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemperatureDetailPage : ContentPage
    {
        public double Latitude;
        public double Longitude;

        public TemperatureDetailPage()
        {
            InitializeComponent();

            BindingContext = new TemperatureDetailViewModel();
        }

        public TemperatureDetailPage(TemperatureDetailViewModel temperatureSelected)
        {
            InitializeComponent();

            BindingContext = temperatureSelected;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
                await Navigation.PopAsync();
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}