using System.ComponentModel.Composition;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    [Export("CustomerEditView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class CustomerEditView : IView
    {
        public CustomerEditView()
        {
            InitializeComponent();
        }
    }
}
