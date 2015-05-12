using System.ComponentModel.Composition;
using Mita.Mvvm.ViewModels;

namespace BookStore.PayDesk
{
    [Export(typeof(IViewModelManager<IChildViewModel>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewModelManager : ChildViewModelManager
    {
    }
}
