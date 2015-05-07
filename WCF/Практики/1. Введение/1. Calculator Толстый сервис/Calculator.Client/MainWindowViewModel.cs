using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Calculator.Client
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public int A
        {
            get { return _a; }
            set { _a = value; OnPropertyChanged(); }
        }

        public int B
        {
            get { return _b; }
            set { _b = value; OnPropertyChanged(); }
        }

        public int Sum
        {
            get { return _sum; }
            set { _sum = value; OnPropertyChanged(); }
        }

        private DelegateCommand _sumCommand;
        private int _a;
        private int _b;
        private int _sum;

        public ICommand SumCommand
        {
            get { return _sumCommand ?? (_sumCommand = new DelegateCommand(CalcSum)); }
        }

        private async void CalcSum()
        {
            var service = new CalculatorServiceReference.CalculatorServiceClient();
            
            int sum = await service.SumAsync(A, B);

            Sum = sum;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
