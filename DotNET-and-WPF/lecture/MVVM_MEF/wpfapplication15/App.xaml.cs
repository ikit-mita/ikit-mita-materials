using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using ViewModel;

namespace WpfApplication15
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var assembly =
               new AssemblyCatalog(Assembly.GetEntryAssembly());


            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("."));


            var compositionContainer
                = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);

            var locator = new MefServiceLocator(compositionContainer);
            ServiceLocator.SetLocatorProvider(() => locator);


            ViewModelManager.ViewModelShowEvent
                += vm => ViewManager.ViewShow(vm);
            ViewModelManager.ViewModelCloseEvent
                += vm => ViewManager.ViewClose(vm);

            var mainWindowViewModel = new MainWindowViewModel();
            compositionContainer.ComposeParts(mainWindowViewModel);
           
            MainWindow mainWindow = new MainWindow {DataContext = mainWindowViewModel};
            mainWindow.Show();
        }

        [Import]
        public IViewModelManager ViewModelManager { get; set; }
        
        [Import]
        public IViewManager ViewManager { get; set; }
    }
}
