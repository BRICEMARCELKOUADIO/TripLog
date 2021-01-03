using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using TripLog.ViewModels.Base;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                SetProperty(ref _entry, value);
            }
        }

        public DetailViewModel(TripLogEntry entry)
        {
            Entry = entry;
        }
    }
}
