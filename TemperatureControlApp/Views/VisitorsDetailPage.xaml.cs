using System;
using TemperatureControlApp.Models;
using TemperatureControlApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemperatureControlApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorsDetailPage : ContentPage
    {
        public VisitorsDetailPage()
        {
            InitializeComponent();

            BindingContext = new VisitorsDetailViewModel();
        }

        public VisitorsDetailPage(VisitorsDetailViewModel visitorSelected)
        {
            InitializeComponent();

            BindingContext = visitorSelected;
        }

        public VisitorModel VisitorSelected;

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}