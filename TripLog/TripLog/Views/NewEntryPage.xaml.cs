using System;
using System.Collections.Generic;
using System.Linq;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryPage : ContentPage
    {
        NewEntryViewModel ViewModel => BindingContext as NewEntryViewModel;
        public NewEntryPage()
        {
            InitializeComponent();
            BindingContextChanged += Page_BindingContextChanged;
            BindingContext = new NewEntryViewModel();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Page_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        private void ViewModel_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            var propHasError = (ViewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;
            switch (e.PropertyName)
            {
                case nameof(ViewModel.Title):
                    title.LabelColor = propHasError ? Color.Red : Color.Black;
                    break;
                case nameof(ViewModel.Rating):
                    rating.LabelColor = propHasError ? Color.Red : Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}