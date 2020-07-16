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

        public VisitorsDetailPage(VisitorModel visitorSelected)
        {
            InitializeComponent();

            BindingContext = new VisitorsDetailViewModel(visitorSelected);
        }
    }
}