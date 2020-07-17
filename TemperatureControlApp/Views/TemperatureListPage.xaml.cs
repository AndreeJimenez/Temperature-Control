using System;
using System.ComponentModel;
using TemperatureControlApp.Models;
using TemperatureControlApp.ViewModels;
using Xamarin.Forms;

namespace TemperatureControlApp.Views
{
    [DesignTimeVisible(false)]
    public partial class TemperatureListPage : ContentPage
    {
        public TemperatureListPage()
        {
            InitializeComponent();

            BindingContext = new TemperatureViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (TemperatureModel)layout.BindingContext;
            await Navigation.PushAsync(new TemperatureDetailPage(new TemperatureDetailViewModel(item)));
        }

        async void AddTemperature_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TemperatureDetailPage());
        }
    }
}