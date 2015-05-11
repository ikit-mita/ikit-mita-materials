using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;

namespace Mita.Mvvm.Views
{
    public abstract class ViewManagerBase<TVm> : IViewManager<TVm> where TVm : IViewModel
    {
        protected readonly IServiceLocator ServiceLocator;

        protected ViewManagerBase(IViewModelManager<TVm> vmManager, IServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
            vmManager.ViewModelShown += OnViewModelShown;
            vmManager.ViewModelClosed += OnViewModelClosed;
        }

        private void OnViewModelShown(object sender, ViewModelEventArgs<TVm> e)
        {
            ShowViewForViewModel(e.ViewModel);
        }

        private void OnViewModelClosed(object sender, ViewModelEventArgs<TVm> e)
        {
            CloseViewForViewModel(e.ViewModel);
        }

        public abstract void ShowViewForViewModel(TVm viewModel);

        public abstract void CloseViewForViewModel(TVm viewModel);

        protected IView ResolveView(Type viewModelType)
        {
            var contractName = GetViewContractName(viewModelType);
            var view = ResolveView(contractName);
            return view;
        }

        protected IView ResolveView(string contractName)
        {
            var view = ServiceLocator.GetInstance<IView>(contractName);
            return view;
        }

        protected string GetViewContractName(Type viewModelType)
        {
            string contractName = viewModelType.Name.Replace("ViewModel", "View");

            if (viewModelType.IsGenericType)
            {
                List<string> parts = viewModelType.GetGenericArguments()
                    .Select(t => t.Name)
                    .ToList();

                var indexOfGenParam = viewModelType.Name.IndexOf('`');
                var vmTypeName = viewModelType.Name.Substring(0, indexOfGenParam);
                parts.Add(vmTypeName.Replace("ViewModel", "View"));

                contractName = string.Join("_", parts);
            }

            return contractName;
        }
    }
}
