using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {
        private string _data;
        private ICommand _getDataCommand;

        public string Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public ICommand GetDataCommand
        {
            get { return _getDataCommand ?? (_getDataCommand = new DelegateCommand(GetData)); }
        }

        private async void GetData()
        {
            var serviceClient = new TestServiceReference.TestServiceClient();
            
            var data = await serviceClient.GetDataAsync();

            Data = data;
        }
    }
}
