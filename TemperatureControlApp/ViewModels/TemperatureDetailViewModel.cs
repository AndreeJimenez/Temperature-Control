using TemperatureControlApp.Models;
using TemperatureControlApp.Services;
using Plugin.Media;
using System;
using Xamarin.Forms;

namespace TemperatureControlApp.ViewModels
{
    public class TemperatureDetailViewModel : BaseViewModel
    {
        Command saveCommand;
        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(SaveAction));

        Command deleteCommand;
        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(DeleteAction));

        TemperatureModel temperatureSelected;
        public TemperatureModel TemperatureSelected
        {
            get => temperatureSelected;
            set => SetProperty(ref temperatureSelected, value);
        }

        string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => SetProperty(ref _Date, value);
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
            await App.Database.SaveTemperatureAsync(TemperatureSelected);
            TemperatureViewModel.GetInstance().LoadTemperatures();
        }

        private async void DeleteAction()
        {
            await App.Database.DeleteTemperatureAsync(TemperatureSelected);
            TemperatureViewModel.GetInstance().LoadTemperatures();
        }
    }
}
