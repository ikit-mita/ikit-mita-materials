using Mita.Mvvm.ViewModels;

namespace Mita.Mvvm.Views
{
    public interface IViewManager<in TVm> where TVm : IViewModel
    {
        void ShowViewForViewModel(TVm viewModel);
        void CloseViewForViewModel(TVm viewModel);
    }
}
