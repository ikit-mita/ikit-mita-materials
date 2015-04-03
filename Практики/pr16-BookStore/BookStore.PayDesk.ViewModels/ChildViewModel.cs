using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;

namespace BookStore.PayDesk.ViewModels
{
    public class ChildViewModel : ChildViewModelBase
    {
        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected override IServiceLocator ServiceLocator
        {
            get { return base.ServiceLocator; }
            set { base.ServiceLocator = value; }
        }

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected override IViewModelManager<IChildViewModel> ViewModelManager
        {
            get { return base.ViewModelManager; }
            set { base.ViewModelManager = value; }
        }
    }
}
