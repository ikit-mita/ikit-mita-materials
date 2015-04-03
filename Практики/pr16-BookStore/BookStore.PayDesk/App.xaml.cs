using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using BookStore.PayDesk.ViewModels;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var assembly = new AssemblyCatalog(Assembly.GetEntryAssembly());
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            var mefServiceLocator = new MefServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => mefServiceLocator);
            container.ComposeExportedValue<IServiceLocator>(mefServiceLocator);
            container.ComposeParts(this);

            Locator.GetInstance<IViewManager<IChildViewModel>>();

            var loginViewModel = Locator.GetInstance<LoginViewModel>();
            loginViewModel.Show();
        }

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        public IServiceLocator Locator { get; set; }
    }
}
