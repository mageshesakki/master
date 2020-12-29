using GlobussoftTechnologies.ChatlistUIModule.Model;
using GlobussoftTechnologies.ChatlistUIModule.Services;
using GlobussoftTechnologies.ChatlistUIModule.ViewModels;
using GlobussoftTechnologies.ChatlistUIModule.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace GlobussoftTechnologies.ChatlistUIModule
{
    public class ChatListUIModule : IModule
    {
        #region private properties        
        /// <summary>        
        /// Instance of IRegionManager        
        /// </summary>        
        private IRegionManager _regionManager;

        #endregion

        #region Constructor        
        /// <summary>        
        /// parameterized constructor initializes IRegionManager        
        /// </summary>        
        /// <param name="regionManager"></param>        
        public ChatListUIModule(IRegionManager regionManager )
        {
            _regionManager = regionManager;
        }
        #endregion

        #region Interface methods        
        /// <summary>        
        /// Initializes ChatListControl of your application.        
        /// </summary>        
        /// <param name="containerProvider"></param>        
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ChatListRegion", typeof(ChatList));
            regionManager.RegisterViewWithRegion("ChatDetailsRegion", typeof(ChatDetails));         
        }

        /// <summary>        
        /// RegisterTypes used to register modules        
        /// </summary>        
        /// <param name="containerRegistry"></param>        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataService, DataService>();
            ViewModelLocationProvider.Register<ChatList, ChatListViewModel>();
            ViewModelLocationProvider.Register<ChatDetails, ChatDetailsViewModel>(); 
        }


        #endregion Interface methods        
    }
}
