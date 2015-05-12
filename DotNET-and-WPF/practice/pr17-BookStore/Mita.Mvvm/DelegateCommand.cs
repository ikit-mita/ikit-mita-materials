using System;
using System.ComponentModel;
using Mita.Core;

namespace Mita.Mvvm
{


    public class DelegateCommand : DelegateCommandBase
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecutePredicate;

        public DelegateCommand(Action action, Func<bool> canExecutePredicate = null)
        {
            _action = action;
            _canExecutePredicate = canExecutePredicate;
        }

        protected override bool CanExecute(object parameter)
        {
            return _canExecutePredicate == null || _canExecutePredicate();
        }

        protected override void Execute(object parameter)
        {
            _action();
        }
    }

    public class DelegateCommand<T> : DelegateCommandBase
    {
        private readonly TypeConverter _typeConverter = TypeDescriptor.GetConverter(typeof(T));
        private readonly Action<T> _action;
        private readonly Predicate<T> _canExecutePredicate;

        public DelegateCommand(Action<T> action, Predicate<T> canExecutePredicate = null)
        {
            _action = action;
            _canExecutePredicate = canExecutePredicate;
        }

        protected override bool CanExecute(object parameter)
        {
            return _canExecutePredicate == null || _canExecutePredicate(ConvertParam(parameter));
        }

        protected override void Execute(object parameter)
        {
            T p = ConvertParam(parameter);
            _action(p);
        }

        private T ConvertParam(object parameter)
        {
            T p;
            if (parameter is T)
            {
                p = (T)parameter;
            }
            else if (parameter == null)
            {
                p = default(T);
            }
            else if (_typeConverter.CanConvertFrom(parameter.GetType()))
            {
                p = (T)_typeConverter.ConvertFrom(parameter);
            }
            else
            {
                throw new ArgumentException("Type {0} can't be converted from {1}.".FormatWith(typeof(T).FullName, parameter.GetType().FullName), "parameter");
            }

            return p;
        }
    }

}
