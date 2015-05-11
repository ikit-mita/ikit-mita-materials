using System.ComponentModel.Composition;

namespace WpfApplication15

{
    [Export("ChildView", typeof(IChildView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ChildView : IChildView
    {
        public ChildView()
        {
            InitializeComponent();
        }


    }
}
