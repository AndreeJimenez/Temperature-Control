using TemperatureControlApp.Models;
using TemperatureControlApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TemperatureControlApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemperatureMapPage : ContentPage
    {
        public TemperatureMapPage(TemperatureModel temperatureSelected)
        {
            InitializeComponent();

            MapTemperature.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(temperatureSelected.Latitude, temperatureSelected.Longitude),
                    Distance.FromMiles(.5)
            ));

            MapTemperature.Temperature = temperatureSelected;

            MapTemperature.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = temperatureSelected.Comments,
                    Position = new Position(temperatureSelected.Latitude, temperatureSelected.Longitude)
                }
            );

            Comments.Text = temperatureSelected.Comments;
        }
    }
}