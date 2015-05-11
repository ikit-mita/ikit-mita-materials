using System.ComponentModel.Composition;

namespace WpfApplication15
{
    [Export("ChildView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class MainWindow : IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
