using System;

namespace Mita.Mvvm.ViewModels
{
    public class ViewModelEventArgs<TVm> : EventArgs where TVm : IViewModel
    {
        public ViewModelEventArgs(TVm viewModel)
        {
            ViewModel = viewModel;
        }

        public TVm ViewModel { get; private set; }
    }
}
