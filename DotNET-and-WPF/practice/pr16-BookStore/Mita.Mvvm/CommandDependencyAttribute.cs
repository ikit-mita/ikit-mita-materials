using System;
using Mita.Mvvm.Annotations;

namespace Mita.Mvvm
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CommandDependencyAttribute : Attribute
    {
        public CommandDependencyAttribute([NotNull]string commandPropertyName)
        {
            CommandPropertyName = commandPropertyName;
        }

        public string CommandPropertyName { get; private set; }
    }
}
