using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication15
{
    public interface IView
    {
        object DataContext { get; set; }
    }
}
