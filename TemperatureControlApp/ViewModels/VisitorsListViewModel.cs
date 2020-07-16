using TemperatureControlApp.Models;
using TemperatureControlApp.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TemperatureControlApp.ViewModels
{
    public class VisitorsListViewModel : BaseViewModel
    {
        static VisitorsListViewModel instance;

        Command refreshCommand;
        public Command RefreshCommand => refreshCommand ?? (refreshCommand = new Command(LoadVisitors));

        Command _newCommand;
        public Command NewCommand => _newCommand ?? (_newCommand = new Command(NewAction));

        Command _selectCommand;
        public Command SelectCommand => _selectCommand ?? (_selectCommand = new Command(SelectAction));

        List<VisitorModel> pets;
        public List<VisitorModel> Visitors
        {
            get => pets;
            set => SetProperty(ref pets, value);
        }

        VisitorModel visitorSelected;
        public VisitorModel VisitorSelected
        {
            get => visitorSelected;
            set
            {
                if (SetProperty(ref visitorSelected, value))
                {
                    SelectAction();
                }
            }
        }

        public VisitorsListViewModel()
        {
            instance = this;

            LoadVisitors();
        }

        public static VisitorsListViewModel GetInstance()
        {
            if (instance == null) instance = new VisitorsListViewModel();
            return instance;
        }

        public async void LoadVisitors()
        {
            Visitors = await App.Database.GetAllVisitorsAsync();
            IsBusy = false;
        }

        private void NewAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new VisitorsDetailPage());
        }

        private void SelectAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new VisitorsDetailPage(VisitorSelected));
        }
    }
}