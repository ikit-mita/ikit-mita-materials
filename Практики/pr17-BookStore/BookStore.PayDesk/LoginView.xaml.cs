using System.ComponentModel.Composition;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    [Export("LoginView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class LoginView : IView
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}
