using GlobussoftTechnologies.ChatlistUIModule.Model;
using GlobussoftTechnologies.ChatlistUIModule.Services;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GlobussoftTechnologies.ChatlistUIModule.ViewModels
{
    public class ChatListViewModel : ViewModelBase
    {
        #region Private property

        private ObservableCollection<Users> _users;

        private IDataService _dataService;

        private IEventAggregator _eventAggregator;

        private Users _selectedUser;

        #endregion Private property

        #region Public property
        public ObservableCollection<Users> Users
        {
            get
            {
                return _users;
            }
            set
            {
                if (value != _users)
                {
                    _users = value;
                    OnPropertyChanged("Users");
                }
            }
        }

        public IDataService DataService
        {
            get
            {
                return _dataService;
            }
            set
            {
                if (value != _dataService)
                {
                    _dataService = value;
                    OnPropertyChanged("DataService");
                }
            }
        }

        public Users SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                if (value != _selectedUser)
                {
                    _selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                    // Publish event.
                    this._eventAggregator.GetEvent<PubSubEvent<Users>>().Publish(this.SelectedUser);
                    SelectedUserId = SelectedUser.Id;
                }
            }
        }

        #endregion Public property

        #region Constructor
        public ChatListViewModel(IDataService dataservice, IEventAggregator eventAggregator, IContainerProvider containerProvider)
        {
            _dataService = dataservice;
            _eventAggregator = eventAggregator;

            // Load Data
            LoadData();
        }

        #endregion Constructor

        #region Private Method
        private void LoadData()
        {
            try
            {
                // Get current user id
                CurrentUserId = _dataService.GetCurrentDetail().Id;

                // Get all users
                var users = _dataService.GetUsers();

                // Remove the current use from list
                var currentuser = users.Where(i => i.Id == CurrentUserId).SingleOrDefault();
                if (currentuser != null)
                    users.Remove(currentuser);

                Users = users;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        #endregion Private Method
    }
}
