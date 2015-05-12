using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.Core;
using Mita.Mvvm;
using Mita.Mvvm.ViewModels;

namespace BookStore.PayDesk.ViewModels
{
    [Export]
    public class LoginViewModel : ChildViewModel
    {
        private string _login;
        private string _password;

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(MakeLogin, () => !Login.IsNullOrEmpty() && !Password.IsNullOrEmpty());
        }

        [CommandDependency("LoginCommand")]
        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        [CommandDependency("LoginCommand")]
        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand LoginCommand { get; private set; }

        private void MakeLogin()
        {

        }

    }
}
