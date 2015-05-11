using System;
using System.Collections.Generic;

namespace Mita.Mvvm.ViewModels
{
    public class ChildViewModelManager : IViewModelManager<IChildViewModel>
    {
        private readonly HashSet<IChildViewModel> _openedViewModels = new HashSet<IChildViewModel>();

        public void ShowViewModel(IChildViewModel viewModel)
        {
            if (_openedViewModels.Add(viewModel))
            {
                OnViewModelShown(viewModel);
            }
        }

        public void CloseViewModel(IChildViewModel viewModel)
        {
            if (_openedViewModels.Remove(viewModel))
            {
                OnViewModelClosed(viewModel);
            }
        }

        public event EventHandler<ViewModelEventArgs<IChildViewModel>> ViewModelShown;
        public event EventHandler<ViewModelEventArgs<IChildViewModel>> ViewModelClosed;

        protected virtual void OnViewModelShown(IChildViewModel vm)
        {
            var handler = ViewModelShown;
            if (handler != null) handler(this, new ViewModelEventArgs<IChildViewModel>(vm));
        }

        protected virtual void OnViewModelClosed(IChildViewModel vm)
        {
            var handler = ViewModelClosed;
            if (handler != null) handler(this, new ViewModelEventArgs<IChildViewModel>(vm));
        }
    }
}
