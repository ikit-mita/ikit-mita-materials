using System.Collections.Generic;
using System.Windows.Input;
using Client.Logic;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Shared.Model;

namespace Client
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly OrderRepositoryProxy _orderRepositoryProxy = new OrderRepositoryProxy();

        private ICommand _getPlainOrdersCommand;
        private ICommand _getOrdersCommand;
        
        private List<Order> _plainOrders;
        private List<Order> _orders;

        public ICommand GetPlainOrdersCommand
        {
            get { return _getPlainOrdersCommand ?? (_getPlainOrdersCommand = new DelegateCommand(GetPlainOrders)); }
        }
        public ICommand GetOrdersCommand
        {
            get { return _getOrdersCommand ?? (_getOrdersCommand = new DelegateCommand(GetOrders)); }
        }
        
        public List<Order> PlainOrders
        {
            get { return _plainOrders; }
            set { SetProperty(ref _plainOrders, value); }
        }

        public List<Order> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }

        private async void GetOrders()
        {
            Orders = await _orderRepositoryProxy.GetOrdersAsync(new OrderRequest{IncludeOrderItems = true, IncludeCustomer = true});
        }

        private async void GetPlainOrders()
        {
            PlainOrders = await _orderRepositoryProxy.GetOrdersAsync(new OrderRequest());
        }
    }
}
