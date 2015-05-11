using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _openCommand;
  
        public RelayCommand OpenCommand
        {
            get { return _openCommand ?? (_openCommand = new RelayCommand(OnOpen)); }
        }

        private void OnOpen()
        {
            var cildViewModel = new ChildViewModel();
            ViewModelManager.ViewModelShow(cildViewModel);
            cildViewModel.Closed+=new EventHandler(cildViewModel_Closed);
        }

        [Import]
        public IViewModelManager ViewModelManager { get; set; }

        private void cildViewModel_Closed(object sender, EventArgs e)
        {
            var dataContext = (ChildViewModel) sender;
        }
    }
}
