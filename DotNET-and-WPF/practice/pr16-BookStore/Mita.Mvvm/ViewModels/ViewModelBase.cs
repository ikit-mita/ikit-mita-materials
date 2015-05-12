using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mita.Mvvm.Annotations;

namespace Mita.Mvvm.ViewModels
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));

            PropertyInfo property = GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            if (property == null)
            {
                return;
            }

            var commands = Attribute.GetCustomAttributes(property, typeof(CommandDependencyAttribute))
                .Cast<CommandDependencyAttribute>()
                .Select(cda => GetType().GetProperty(cda.CommandPropertyName, BindingFlags.Instance | BindingFlags.Public))
                .Where(cp => cp != null)
                .Select(cp => cp.GetValue(this))
                .OfType<ICommand>()
                .ToArray();

            foreach (var command in commands)
            {
                var deligateCommand = command as DelegateCommandBase;

                if (deligateCommand != null)
                {
                    deligateCommand.RaiseCanExecuteChanged();
                }
            }
        }

    }
}
