using TemperatureControlApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TemperatureControlApp.ViewModels
{
    public class VisitorsListViewModel : BaseViewModel
    {
        static VisitorsListViewModel instance;

        Command refreshCommand;
        public Command RefreshCommand => refreshCommand ?? (refreshCommand = new Command(LoadVisitors));

        List<VisitorModel> visitors;
        public List<VisitorModel> Visitors
        {
            get => visitors;
            set => SetProperty(ref visitors, value);
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
    }
}