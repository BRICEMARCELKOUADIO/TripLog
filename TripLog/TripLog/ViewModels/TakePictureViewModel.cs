using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TripLog.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class TakePictureViewModel : BaseViewModel
    {
        private ImageSource _imagePick;
        public ImageSource ImagePick
        {
            get => _imagePick;
            set => SetProperty(ref _imagePick, value);
        }

        private ICommand _takePictureCommand;
        public ICommand TakePictureCommand => _takePictureCommand ?? (_takePictureCommand = new Command(TakePicture));

        public TakePictureViewModel()
        {

        }
        private async void TakePicture()
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "Please take a picture"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                ImagePick = ImageSource.FromStream(() => stream);
            }
        }

    }
}
