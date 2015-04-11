using System;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;

namespace BookStore.PayDesk.ViewModels
{
    public class ChildViewModel : ChildViewModelBase
    {
        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected virtual IServiceLocator ServiceLocator { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected override IViewModelManager<IChildViewModel> ViewModelManager
        {
            get { return base.ViewModelManager; }
            set { base.ViewModelManager = value; }
        }
    }
}
