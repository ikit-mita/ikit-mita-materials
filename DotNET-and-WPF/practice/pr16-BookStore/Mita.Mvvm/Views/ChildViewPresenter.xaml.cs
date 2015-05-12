using System;
using System.ComponentModel;
using Mita.Mvvm.ViewModels;

namespace Mita.Mvvm.Views
{
    /// <summary>
    /// Interaction logic for ChildViewPresenter.xaml
    /// </summary>
    public partial class ChildViewPresenter 
    {
        public ChildViewPresenter()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!((IChildViewModel)DataContext).IsClosed)
            {
                e.Cancel = true;
                Dispatcher.BeginInvoke(new Action(() => ((IChildViewModel)DataContext).Close()));
            }
        }
    }
}
