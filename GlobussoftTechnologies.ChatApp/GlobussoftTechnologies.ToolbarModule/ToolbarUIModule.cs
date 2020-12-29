using GlobussoftTechnologies.ToolbarModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ToolbarModule
{
    public class ToolbarUIModule : IModule
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
        public ToolbarUIModule(IRegionManager regionManager)
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
            regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(ToolbarView));
        }

        /// <summary>        
        /// RegisterTypes used to register modules        
        /// </summary>        
        /// <param name="containerRegistry"></param>        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }


        #endregion Interface methods        
    }
}
