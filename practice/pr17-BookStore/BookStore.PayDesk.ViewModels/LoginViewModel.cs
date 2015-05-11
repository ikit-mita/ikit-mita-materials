using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess;
using BookStore.DataAccess.Model;
using Mita.Core;
using Mita.DataAccess;
using Mita.Mvvm;
using Mita.Mvvm.ViewModels;

namespace BookStore.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginViewModel : ChildViewModel
    {
        private string _login;
        private string _password;
        private string _errorMessage;

        [Import]
        private IRepositoryProvider RepositoryProvider { get; set; }

        public LoginViewModel()
        {
            Title = "Login";
            LoginCommand = new DelegateCommand(() => Task.Run((Action)MakeLogin), () => !Login.IsNullOrEmpty() && !Password.IsNullOrEmpty());

#if DEBUG
            Login = "admin";
            Password = "admin";
#endif
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

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value == _errorMessage) return;
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private void MakeLogin()
        {
            try
            {
                using (StartOperation())
                {
                    var user = RepositoryProvider.GetRepository<User>().GetAll()
                        .FirstOrDefault(u => u.Login == Login);

                    if (user == null || !PasswordManager.ValidatePassword(Password, user.Password))
                    {
                        ErrorMessage = "Incorrect login or password.";
                    }
                    else
                    {
                        var mainViewModel = ServiceLocator.GetInstance<MainViewModel>();
                        mainViewModel.InitializeAsync(user.Id);
                        mainViewModel.Show();
                        Close(true);
                    }
                }
            }
            catch (Exception exc)
            {
                ErrorMessage = "Can't connect to database. Try again.";
                Debug.WriteLine(exc.ExpandToString());
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }
    }
}
