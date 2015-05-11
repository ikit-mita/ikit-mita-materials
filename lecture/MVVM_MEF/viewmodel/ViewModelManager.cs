using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public interface IViewModelManager
    {
        event ViewModelManager.ViewModelShowDelegate ViewModelShowEvent;
        event ViewModelManager.ViewModelCloseDelegate ViewModelCloseEvent;
        void ViewModelShow(ViewModelBase viewModel);
    }

    [Export (typeof(IViewModelManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewModelManager : IViewModelManager
    {
        public delegate void ViewModelShowDelegate(ViewModelBase viewModel);

        public event ViewModelShowDelegate ViewModelShowEvent;

        public void ViewModelShow (ViewModelBase viewModel)
        {
            OnViewModelShowEvent(viewModel);
            viewModel.Closed += (sender, args) => ViewModelClose((ViewModelBase) sender);
        }

        private void OnViewModelShowEvent(ViewModelBase viewmodel)
        {
            ViewModelShowDelegate handler = ViewModelShowEvent;
            if (handler != null) handler(viewmodel);
        }


        public delegate void ViewModelCloseDelegate(ViewModelBase viewModel);

        public event ViewModelCloseDelegate ViewModelCloseEvent;

        public void ViewModelClose(ViewModelBase viewModel)
        {
            OnViewModelCloseEvent(viewModel);
        }

        private void OnViewModelCloseEvent(ViewModelBase viewmodel)
        {
            ViewModelCloseDelegate handler = ViewModelCloseEvent;
            if (handler != null) handler(viewmodel);
        }
    }
}
