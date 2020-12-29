using GlobussoftTechnologies.ChatlistUIModule.Model;
using GlobussoftTechnologies.ChatlistUIModule.Services;
using GlobussoftTechnologies.ChatlistUIModule.ViewModel;
using Prism.Events;
using Prism.Ioc;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GlobussoftTechnologies.ChatlistUIModule.ViewModels
{
    public class ChatDetailsViewModel : ViewModelBase
    {
        #region Private property

        private ObservableCollection<ChatLists> _chatDetails;
        private IDataService _dataService;
        private IEventAggregator _eventAggregator;
        private Users _selectedUser;
        private string _lastVisited;
        private string _userName;
        private string _message;
        private int _selectedIndex = 0;
        #endregion Private property

        #region Public property
        public ObservableCollection<ChatLists> ChatDetails
        {
            get
            {
                return _chatDetails;
            }
            set
            {
                if (value != _chatDetails)
                {
                    _chatDetails = value;
                    OnPropertyChanged("ChatDetails");
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
                }
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }
            }

        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }

        }

        public string LastVisited
        {
            get
            {
                return _lastVisited;
            }
            set
            {
                if (_lastVisited != value)
                {
                    _lastVisited = value;
                    OnPropertyChanged("LastVisited");
                }
            }

        }

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                if (value != _selectedIndex)
                {
                    _selectedIndex = value;
                    OnPropertyChanged("DataService");
                }
            }
        }

        #endregion Public property

        #region Command
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(p => AddDetails());
                return addCommand;
            }
        }
        #endregion

        #region Constructor
        public ChatDetailsViewModel(IDataService dataservice, IEventAggregator eventAggregator, IContainerProvider containerProvider)
        {
            _dataService = dataservice;
            _eventAggregator = eventAggregator;

            // Initalize
            Intialize(containerProvider);
        }


        #endregion Constructor

        #region Private Method

        /// <summary>        
        /// Method to Intialize    
        /// </summary> 
        private void Intialize(IContainerProvider containerProvider)
        {
            // Get current user details
            CurrentUserId = _dataService.GetCurrentDetail().Id;
           
            LastVisited = "Long time ago";
            var chatListViewModel = containerProvider.Resolve<ChatListViewModel>();
            if (chatListViewModel.Users != null && chatListViewModel.Users.Count > 0)
                LoadData(CurrentUserId, chatListViewModel.Users[0].Id);
            _eventAggregator.GetEvent<PubSubEvent<Users>>().Subscribe((details) => { LoadData(CurrentUserId, details.Id); }, true);
        }

        /// <summary>        
        /// Method to LoadData    
        /// </summary> 
        private void LoadData(long currentUserId, long selectedUserId)
        {
            // Load selected user chat deatils
            UserName = _dataService.GetUser(selectedUserId).Name;
            SelectedUserId = selectedUserId;
            ChatDetails = _dataService.GetChatDetails(currentUserId, selectedUserId);
        }

        /// <summary>        
        /// Method to LoadData    
        /// </summary> 
        private void AddDetails()
        {
            // Save details in database
            _dataService.AddDetails(CurrentUserId, SelectedUserId, Message);

            if (ChatDetails.Count > 0)
                ChatDetails.Clear();

            // Refresh items
            ChatDetails = _dataService.GetChatDetails(CurrentUserId, SelectedUserId);

            // Clear message
            Message = string.Empty;
        }

        #endregion Private Method
    }
}
