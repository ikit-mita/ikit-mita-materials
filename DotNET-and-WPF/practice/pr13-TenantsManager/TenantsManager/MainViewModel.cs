using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Expression.Interactivity.Core;
using TenantsManager.Annotations;
using TenantsManager.Model;

namespace TenantsManager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TenantRepository _repository = new TenantRepository();
        private Tenant _selectedTenant;
        private ICollection<Tenant> _tenands;
        private bool _showDeleted;

        public ICollection<Tenant> Tenands
        {
            get { return _tenands; }
            set
            {
                if (Equals(value, _tenands)) return;
                _tenands = value;
                OnPropertyChanged();
            }
        }

        public Tenant SelectedTenant
        {
            get { return _selectedTenant; }
            set
            {
                if (Equals(value, _selectedTenant)) return;
                _selectedTenant = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ReloadTenands();

            CreateTenantCommand = new ActionCommand(CreateTenant);
            AddNewTenantCommand = new ActionCommand(AddNewTenant);
            DeleteTenantCommand = new ActionCommand(DeleteTenant);
        }

        private void DeleteTenant()
        {
            //_repository.Remove(SelectedTenant); - мы не должны удалять жителей из БД
            SelectedTenant.IsDeleted = true;
            ReloadTenands();
            SelectedTenant = null;
        }

        public ActionCommand CreateTenantCommand { get; private set; }
        public ActionCommand AddNewTenantCommand { get; private set; }
        public ActionCommand DeleteTenantCommand { get; private set; }

        public bool ShowDeleted
        {
            get { return _showDeleted; }
            set
            {
                _showDeleted = value;
                ReloadTenands();
            }
        }

        private void CreateTenant()
        {
            var tenant = new Tenant
            {
                Birthday = DateTime.Now,
                Debt = 200,
                Name = "new tenant"
            };

            SelectedTenant = tenant;
        }

        private void AddNewTenant()
        {
            var tenant = SelectedTenant;
            _repository.Add(tenant);
            SelectedTenant = null;
            ReloadTenands();
            SelectedTenant = tenant;
        }

        private void ReloadTenands()
        {
            var tanantsQuery = _repository.GetAll();

            if (!ShowDeleted)
            {
                tanantsQuery = tanantsQuery.Where(t => !t.IsDeleted);
            }

            Tenands = tanantsQuery.ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
