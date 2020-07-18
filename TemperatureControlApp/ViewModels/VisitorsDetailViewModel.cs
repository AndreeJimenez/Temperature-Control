using TemperatureControlApp.Models;
using TemperatureControlApp.Services;
using Plugin.Media;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TemperatureControlApp.ViewModels
{
    public class VisitorsDetailViewModel : BaseViewModel
    {
        Command saveCommand;
        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(SaveAction));

        Command deleteCommand;
        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(DeleteAction));

        Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        VisitorModel visitorSelected;
        public VisitorModel VisitorSelected
        {
            get => visitorSelected;
            set => SetProperty(ref visitorSelected, value);
        }

        string _ImageBase64;
        public string ImageBase64
        {
            get => _ImageBase64;
            set => SetProperty(ref _ImageBase64, value);
        }

        string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        string _Gender;
        public string Gender
        {
            get => _Gender;
            set => SetProperty(ref _Gender, value);
        }


        public VisitorsDetailViewModel()
        {
            VisitorSelected = new VisitorModel();
        }

        public VisitorsDetailViewModel(VisitorModel visitorSelected)
        {
            VisitorSelected = visitorSelected;
            ImageBase64 = visitorSelected.ImageBase64;
        }

        private async void SaveAction()
        {
            if(VisitorSelected.Name != null && VisitorSelected.ImageBase64 != null && VisitorSelected.Gender != null && VisitorSelected.Age > 0)
            {
                await App.Database.SaveVisitorAsync(VisitorSelected);
                VisitorsListViewModel.GetInstance().LoadVisitors();
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "You have to fill all the fields", "OK");
            }
        }

        private async void DeleteAction()
        {
            await App.Database.DeleteVisitorAsync(VisitorSelected);
            VisitorsListViewModel.GetInstance().LoadVisitors();
        }

        private async void TakePictureAction()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                await CrossMedia.Current.Initialize();
            }

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            VisitorSelected.ImageBase64 = ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);
        }

        private async void SelectPictureAction()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                await CrossMedia.Current.Initialize();
            }

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Not supported", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            VisitorSelected.ImageBase64 = ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);
        }
    }
}
