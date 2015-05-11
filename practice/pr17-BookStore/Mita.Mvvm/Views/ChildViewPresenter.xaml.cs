using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Shell;
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

            var isBusyBinding = new Binding("IsBusy")
            {
                FallbackValue = false
            };

            SetBinding(IsBusyProperty, isBusyBinding);
        }

        #region ViewResizeMode

        public static readonly DependencyProperty ViewResizeModeProperty = DependencyProperty.RegisterAttached(
            "ViewResizeMode", typeof(ResizeMode), typeof(ChildViewPresenter), new PropertyMetadata(ResizeMode.CanResize));

        public static ResizeMode GetViewResizeMode(DependencyObject element)
        {
            return (ResizeMode)element.GetValue(ViewResizeModeProperty);
        }

        public static void SetViewResizeMode(DependencyObject element, ResizeMode value)
        {
            element.SetValue(ViewResizeModeProperty, value);
        }

        #endregion

        #region ViewMinWidth

        public static readonly DependencyProperty ViewMinWidthProperty = DependencyProperty.RegisterAttached(
            "ViewMinWidth", typeof(double), typeof(ChildViewPresenter), new PropertyMetadata(0d));

        public static void SetViewMinWidth(DependencyObject element, double value)
        {
            element.SetValue(ViewMinWidthProperty, value);
        }

        public static double GetViewMinWidth(DependencyObject element)
        {
            return (double)element.GetValue(ViewMinWidthProperty);
        }

        #endregion

        #region ViewMinHeight

        public static readonly DependencyProperty ViewMinHeightProperty = DependencyProperty.RegisterAttached(
            "ViewMinHeight", typeof(double), typeof(ChildViewPresenter), new PropertyMetadata(0d));

        public static void SetViewMinHeight(DependencyObject element, double value)
        {
            element.SetValue(ViewMinHeightProperty, value);
        }

        public static double GetViewMinHeight(DependencyObject element)
        {
            return (double)element.GetValue(ViewMinHeightProperty);
        }

        #endregion

        #region IsBusy

        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            "IsBusy", typeof(bool), typeof(ChildViewPresenter), new PropertyMetadata(false, OnBusyPropertyChanged));

        private static void OnBusyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var presenter = dependencyObject as ChildViewPresenter;

            if (presenter != null)
            {
                presenter.TaskbarItemInfo.ProgressState = (bool)dependencyPropertyChangedEventArgs.NewValue
                    ? TaskbarItemProgressState.Indeterminate
                    : TaskbarItemProgressState.None;
            }
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!((IChildViewModel)DataContext).IsClosed)
            {
                e.Cancel = true;
                Dispatcher.BeginInvoke(new Action(() => ((IChildViewModel)DataContext).Close()));
            }
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            SizeToContent = SizeToContent.Manual;
        }

        public IView View
        {
            get { return Content as IView; }
            set
            {
                SizeToContent = SizeToContent.WidthAndHeight;
                Content = value;
                OnViewChanged();
            }
        }

        protected void OnViewChanged()
        {
            var dependencyObject = View as DependencyObject;

            if (dependencyObject != null)
            {
                ResizeMode = GetViewResizeMode(dependencyObject);
                MinWidth = GetViewMinWidth(dependencyObject);
                MinHeight = GetViewMinHeight(dependencyObject);
            }
            else
            {
                ResizeMode = ResizeMode.CanResize;
                MinWidth = 0;
                MinHeight = 0;
            }
        }
    }
}
