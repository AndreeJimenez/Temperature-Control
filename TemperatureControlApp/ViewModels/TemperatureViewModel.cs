using TemperatureControlApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TemperatureControlApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        static TemperatureViewModel instance;

        Command refreshCommand;
        public Command RefreshCommand => refreshCommand ?? (refreshCommand = new Command(LoadTemperatures));

        List<TemperatureModel> temperatures;
        public List<TemperatureModel> Temperatures
        {
            get => temperatures;
            set => SetProperty(ref temperatures, value);
        }

        public TemperatureViewModel()
        {
            instance = this;

            LoadTemperatures();
        }

        public static TemperatureViewModel GetInstance()
        {
            if (instance == null) instance = new TemperatureViewModel();
            return instance;
        }

        public async void LoadTemperatures()
        {
            Temperatures = await App.Database.GetAllTemperaturesAsync();
            IsBusy = false;
        }
    }
}