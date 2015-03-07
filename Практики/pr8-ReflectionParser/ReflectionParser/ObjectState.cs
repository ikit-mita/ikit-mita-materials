using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionParser
{
    public enum ObjectState
    {
        Active = 3,

        [EnumDisplayString(DisplayString = "Closed")]
        Closed = 5,

        [EnumDisplayString(DisplayString = "Removed Object")]
        RemovedObject = 7,

        [EnumDisplayString(DisplayString = "I hide this obj")]
        Hidden = 15
    }
}
