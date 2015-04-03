using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.Annotations;

namespace Mita.Mvvm.ViewModels
{
    public abstract class ChildViewModelBase : ViewModelBase, IChildViewModel
    {
        protected virtual IServiceLocator ServiceLocator { get; set; }
        protected virtual IViewModelManager<IChildViewModel> ViewModelManager { get; set; }

        private bool? _modalResult = null;
        private string _title;

        public IChildViewModel Parent { get; protected set; }

        public bool ModalResult { get { return _modalResult.GetValueOrDefault(); } }

        public bool IsClosed { get; protected set; }

        public virtual string Title
        {
            get { return _title; }
            protected set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public void Show()
        {
            ViewModelManager.ShowViewModel(this);
        }

        public void Close(bool modalResult = false)
        {
            IsClosed = true;
            _modalResult = modalResult;
            ViewModelManager.CloseViewModel(this);
            OnClosed();
        }

        public event EventHandler Closed;

        protected virtual void OnClosed()
        {
            var handler = Closed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
