using GlobussoftTechnologies.ChatlistUIModule.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties
        private long _currentUserId;

        private long _selectedUserId;

        public long CurrentUserId
        {
            get
            {
                return _currentUserId;
            }
            set
            {
                if (_currentUserId != value)
                {
                    _currentUserId = value;
                    OnPropertyChanged("CurrentUserId");
                }
            }

        }

        public long SelectedUserId
        {
            get
            {
                return _selectedUserId;
            }
            set
            {
                if (_selectedUserId != value)
                {
                    _selectedUserId = value;
                    OnPropertyChanged("SelectedUserId");
                }
            }

        }

        #endregion Properties

        #region PropertyChanged Event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged Event
    }
}
