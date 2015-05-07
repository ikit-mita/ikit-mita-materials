using System.Windows.Input;
using Client.CompositeTypeServiceReference;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {
        private string _stringRequest;
        private bool _boolRequest;
        private string _stringResponce;
        private bool _boolResponce;
        private bool _answerRequest;
        private Answer _answerResponce;
        private ICommand _compositeTypeCommand;
        private ICommand _answerCommand;

        public string StringRequest
        {
            get { return _stringRequest; }
            set { SetProperty(ref _stringRequest, value); }
        }

        public bool BoolRequest
        {
            get { return _boolRequest; }
            set { SetProperty(ref _boolRequest, value); }
        }

        public string StringResponce
        {
            get { return _stringResponce; }
            set { SetProperty(ref _stringResponce, value); }
        }

        public bool BoolResponce
        {
            get { return _boolResponce; }
            set { SetProperty(ref _boolResponce, value); }
        }

        public bool AnswerRequest
        {
            get { return _answerRequest; }
            set { SetProperty(ref _answerRequest, value); }
        }

        public Answer AnswerResponce
        {
            get { return _answerResponce; }
            set { SetProperty(ref _answerResponce, value); }
        }

        public ICommand CompositeTypeCommand
        {
            get { return _compositeTypeCommand ?? (_compositeTypeCommand = new DelegateCommand(GetCompositeType)); }
            
        }

        public ICommand AnswerCommand
        {
            get { return _answerCommand ?? (_answerCommand = new DelegateCommand(GetAnswer)); }
        }

        private async void GetAnswer()
        {
            var serviceClient = new CompositeTypeServiceClient();

            var res = await serviceClient.EnumTypeAsync(AnswerRequest);

            AnswerResponce = res;
        }

        private async void GetCompositeType()
        {
            var serviceClient = new CompositeTypeServiceClient();
            
            var arg = new CompositeType
            {
                StringValue = StringRequest,
            };
            
            var res = await serviceClient.CompositeTypeAsync(arg);
            
            StringResponce = res.StringValue;
        }
    }
}
