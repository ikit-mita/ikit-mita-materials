using System;
using System.Collections.Concurrent;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;

namespace Mita.Mvvm.Views
{
    public class ChildViewManager : ViewManagerBase<IChildViewModel>
    {
        private readonly ConcurrentDictionary<IChildViewModel, ChildViewPresenter> _openedPresenters =
            new ConcurrentDictionary<IChildViewModel, ChildViewPresenter>();


        public ChildViewManager(IViewModelManager<IChildViewModel> vmManager, IServiceLocator serviceLocator)
            : base(vmManager, serviceLocator)
        {
        }

        public override void ShowViewForViewModel(IChildViewModel viewModel)
        {
            IChildViewModel parentViewModel = viewModel.Parent;
            ChildViewPresenter parentPresenter = null;

            if (parentViewModel != null)
            {
                _openedPresenters.TryGetValue(parentViewModel, out parentPresenter);
            }

            var view = ResolveView(viewModel.GetType());
            var presenter = new ChildViewPresenter
            {
                View = view,
                DataContext = viewModel
            };

            if (parentPresenter != null)
            {
                presenter.ShowInTaskbar = false;
                presenter.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                presenter.Owner = parentPresenter;
            }

            _openedPresenters[viewModel] = presenter;
            presenter.Show();
        }

        public override void CloseViewForViewModel(IChildViewModel viewModel)
        {
            ChildViewPresenter presenter;

            if (_openedPresenters.TryRemove(viewModel, out presenter))
            {
                presenter.Close();
            }
        }
    }
}
