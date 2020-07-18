using TemperatureControlApp.Models;
using TemperatureControlApp.Services;
using Plugin.Media;
using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using TemperatureControlApp.Views;

namespace TemperatureControlApp.ViewModels
{
    public class TemperatureDetailViewModel : BaseViewModel
    {
        Command saveCommand;
        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(SaveAction));

        Command deleteCommand;
        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(DeleteAction));

        Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));

        Command _mapCommand;
        public Command MapCommand => _mapCommand ?? (_mapCommand = new Command(MapAction));

        TemperatureModel temperatureSelected;
        public TemperatureModel TemperatureSelected
        {
            get => temperatureSelected;
            set => SetProperty(ref temperatureSelected, value);
        }

        int _ID;
        public int ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }

        DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => SetProperty(ref _Date, value);
        }

        double _Latitude;
        public double Latitude
        {
            get => _Latitude;
            set => SetProperty(ref _Latitude, value);
        }

        double _Longitude;
        public double Longitude
        {
            get => _Longitude;
            set => SetProperty(ref _Longitude, value);
        }

        public TemperatureDetailViewModel()
        {
            TemperatureSelected = new TemperatureModel();
        }

        public TemperatureDetailViewModel(TemperatureModel temperatureSelected)
        {
            TemperatureSelected = temperatureSelected;
        }

        private async void SaveAction()
        {
            if (TemperatureSelected.Date != null && TemperatureSelected.Latitude != 0 && TemperatureSelected.Longitude != 0 && TemperatureSelected.Comments != null)
            {
                await App.Database.SaveTemperatureAsync(TemperatureSelected);
                TemperatureViewModel.GetInstance().LoadTemperatures();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "You have to fill all the fields", "OK");
            }
        }

        private async void DeleteAction()
        {
            await App.Database.DeleteTemperatureAsync(TemperatureSelected);
            TemperatureViewModel.GetInstance().LoadTemperatures();
        }

        private async void GetLocationAction()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    temperatureSelected.Latitude = location.Latitude;
                    temperatureSelected.Longitude = location.Longitude;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MapAction()
        {
            if (TemperatureSelected.Date != null && TemperatureSelected.Latitude != 0 && TemperatureSelected.Longitude != 0 && TemperatureSelected.Comments != null)
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new TemperatureMapPage(new TemperatureModel
                {
                    ID = TemperatureSelected.ID,
                    Temperature = TemperatureSelected.Temperature,
                    Comments = TemperatureSelected.Comments,
                    Latitude = TemperatureSelected.Latitude,
                    Longitude = TemperatureSelected.Longitude,
                }));
            } 
            else
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "You have to fill all the fields", "OK");
            }
        }
    }
}
