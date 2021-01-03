using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using TripLog.ViewModels.Base;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseValidationViewModel
    {
        string _title;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);

                Validation(() => !string.IsNullOrWhiteSpace(_title), "Title must be provided");

                SaveCommand.ChangeCanExecute();
            }
        }
        double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                SetProperty(ref _latitude, value);
            }
        }
        double _longitude;
        public double Longitude
        {
            get => _longitude;
            set
            {
                SetProperty(ref _longitude, value);
            }
        }
        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                SetProperty(ref _date, value);
            }
        }
        int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                SetProperty(ref _rating, value);
                Validation(() => _rating >= 1 && _rating <= 5, "Rating must be between 1 and 5.");
            }
        }
        string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                SetProperty(ref _notes, value);
            }
        }

        public Command _saveCommand;
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(Save, CanSave));
        bool CanSave(object args) => !string.IsNullOrWhiteSpace(Title) && !HasErrors;

        public NewEntryViewModel()
        {
            Date = DateTime.Today;
            Rating = 1;
        }

        private void Save(object obj)
        {
            var newItem = new TripLogEntry
            {
                Title = Title,
                Latitude = Latitude,
                Longitude = Longitude,
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };
            // TODO: Persist entry in a later chapter
        }
    }
}
