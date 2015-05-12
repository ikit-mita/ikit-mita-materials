using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using ViewModel;

namespace WpfApplication15
{
    public interface IViewManager
    {
        void ViewShow(ViewModelBase viewModel);
        void ViewClose(ViewModelBase viewModel);
    }

    [Export(typeof(IViewManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewManager : IViewManager
    {
        public void ViewShow(ViewModelBase viewModel)
        {
            if (OpenViewModelMapping.ContainsKey(viewModel))
            {
                throw new ArgumentException("View model is open");
            }

            IChildView childView;
            Type viewModelType = viewModel.GetType();

            childView = ServiceLocator.Current.GetInstance<IChildView>
                (viewModelType.Name.Replace("ViewModel", "View"));

            childView.DataContext = viewModel;
            childView.Show();
            OpenViewModelMapping.Add(viewModel, childView);

          

          
        }

        private void OnViewModelClosed(object sender, EventArgs e)
        {
            ViewClose((ViewModelBase) sender);
        }

        public void ViewClose(ViewModelBase viewModel)
        {
            if(OpenViewModelMapping.ContainsKey(viewModel))
            {
                IChildView childView = OpenViewModelMapping[viewModel];
                childView.Close();
             
                OpenViewModelMapping.Remove(viewModel);
            }
        }



        //private readonly  Dictionary<Type, Type> Mapping = 
        //    new Dictionary<Type, Type>
        //        {
        //            {typeof(ChildViewModel), typeof(ChildView)},
        //            {typeof(MainWindowViewModel), typeof(MainWindow)},
        //        };

        private readonly Dictionary<ViewModelBase, IChildView> OpenViewModelMapping = new Dictionary<ViewModelBase, IChildView>();
    }
}
