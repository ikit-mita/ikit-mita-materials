using System.ComponentModel.Composition;
using Mita.Mvvm.Views;

namespace BookStore.PayDesk
{
    /// <summary>
    /// Interaction logic for OrderEditView.xaml
    /// </summary>
    [Export("OrderEditView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class OrderEditView : IView
    {
        public OrderEditView()
        {
            InitializeComponent();
        }
    }
}
