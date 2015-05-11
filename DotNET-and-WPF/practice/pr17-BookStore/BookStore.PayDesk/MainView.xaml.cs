using System.ComponentModel.Composition;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    [Export("MainView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MainView : IView
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
