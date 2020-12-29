using GlobussoftTechnologies.ChatlistUIModule;
using GlobussoftTechnologies.ToolbarModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GlobussoftTechnologies.ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterRequiredTypes(containerRegistry);
        }

        protected override void InitializeShell(Window shell)
        {
            // Extra logic to prepare shell if needed
            Current.MainWindow = shell;
            Current.MainWindow.Show();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type chatListUIModule = typeof(ChatListUIModule);
            moduleCatalog.AddModule(new Prism.Modularity.ModuleInfo
            {
                ModuleName = chatListUIModule.Name,
                ModuleType = chatListUIModule.AssemblyQualifiedName
            });

            Type toolbarUIModule = typeof(ToolbarUIModule);
            moduleCatalog.AddModule(new Prism.Modularity.ModuleInfo
            {
                ModuleName = toolbarUIModule.Name,
                ModuleType = toolbarUIModule.AssemblyQualifiedName
            });

            base.ConfigureModuleCatalog(moduleCatalog);

        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
    }
}
