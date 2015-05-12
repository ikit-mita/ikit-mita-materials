using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionParser
{
    public class EnumDisplayStringAttribute : Attribute
    {
        public string DisplayString { get; set; }
    }
}
