using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    [Export(typeof(IViewManager<IChildViewModel>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewManager : ChildViewManager
    {
        [ImportingConstructor]
        public ViewManager(IViewModelManager<IChildViewModel> vmManager, IServiceLocator serviceLocator) : base(vmManager, serviceLocator)
        {
        }
    }
}
