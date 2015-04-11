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

namespace BookStore.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainViewModel : ChildViewModel
    {
        private string _searchString;
        private string _isbn;
        private Employee _employee;
        private ICollection<BookAmount> _amounts;

        public MainViewModel()
        {
            SearchCommand = new DelegateCommand(() => Task.Run((Action)Search));
            CreateOrderCommand = new DelegateCommand((Action)CreateOrder);
        }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IRepositoryProvider RepositoryProvider { get; set; }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                OnPropertyChanged();
            }
        }

        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if (value == _isbn) return;
                _isbn = value;
                OnPropertyChanged();
            }
        }

        public Employee Employee
        {
            get { return _employee; }
            private set
            {
                if (Equals(value, _employee)) return;
                _employee = value;
                OnPropertyChanged();
            }
        }

        public ICollection<BookAmount> Amounts
        {
            get { return _amounts; }
            set
            {
                if (Equals(value, _amounts)) return;
                _amounts = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SearchCommand { get; private set; }

        public DelegateCommand CreateOrderCommand { get; private set; }

        public Task InitializeAsync(int userId)
        {
            return Task.Run(() => Initialize(userId));
        }

        public void Initialize(int userId)
        {
            using (StartOperation())
            {
                Employee = RepositoryProvider.GetRepository<Employee>()
                    .GetAll(e => e.Branch, e => e.User)
                    .First(e => e.Id == userId);
                Title = "Booko: " + Employee.Branch.Name;
            }
        }

        private void Search()
        {
            using (StartOperation())
            {
                var query = RepositoryProvider.GetRepository<BookAmount>()
                    .GetAll(ba => ba.Book.Writers)
                    .Where(ba => ba.BranchId == Employee.BranchId);

                if (!ISBN.IsNullOrEmpty())
                {
                    query = query.Where(ba => ba.Book.ISBN.Contains(ISBN));
                }
                else if (!SearchString.IsNullOrEmpty())
                {
                    query = query.Where(ba => ba.Book.Title.Contains(SearchString) ||
                                              ba.Book.Writers.Any(w => w.LastName.Contains(SearchString)));
                }
                else
                {
                    Amounts = new BookAmount[] { };
                    return;
                }

                Amounts = query.ToList();
            }
        }

        private void CreateOrder()
        {

        }

        private void OnOrderEditViewModelClosed(object sender, EventArgs e)
        {
            var orderEditViewModel = sender as OrderEditViewModel;

            if (orderEditViewModel != null && orderEditViewModel.ModalResult)
            {
                RepositoryProvider.Dispose();
                RepositoryProvider = ServiceLocator.GetInstance<IRepositoryProvider>();
                Search();
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }
    }
}
