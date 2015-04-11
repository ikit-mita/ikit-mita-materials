using System;

namespace Mita.Mvvm.ViewModels
{
    public interface IChildViewModel : IViewModel
    {
        IChildViewModel Parent { get; }
        bool ModalResult { get; }
        bool IsClosed { get; }
        string Title { get; }

        void Show();
        void Close(bool modalResult = false);
        event EventHandler Closed;
    }
}
