using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    [Export("LoginView", typeof(IView))]
    public partial class LoginView : IView
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}
