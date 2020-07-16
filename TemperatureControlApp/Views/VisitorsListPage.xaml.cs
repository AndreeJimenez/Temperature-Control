using TemperatureControlApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemperatureControlApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitorsListPage : ContentPage
    {
        public VisitorsListPage()
        {
            InitializeComponent();

            BindingContext = new VisitorsListViewModel();
        }
    }
}