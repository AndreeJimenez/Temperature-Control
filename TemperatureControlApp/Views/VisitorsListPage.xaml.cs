using System;
using System.ComponentModel;
using TemperatureControlApp.Models;
using TemperatureControlApp.ViewModels;
using Xamarin.Forms;

namespace TemperatureControlApp.Views
{
    [DesignTimeVisible(false)]
    public partial class VisitorsListPage : ContentPage
    {
        public VisitorsListPage()
        {
            InitializeComponent();

            BindingContext = new VisitorsListViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (VisitorModel)layout.BindingContext;
            await Navigation.PushAsync(new VisitorsDetailPage(new VisitorsDetailViewModel(item)));
        }

        async void AddVisitor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VisitorsDetailPage());
        }
    }
}