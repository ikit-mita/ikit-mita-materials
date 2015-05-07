using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost.Model
{
    [DataContract]
    
    public class Shape { }

    [DataContract]
    public class Circle : Shape { }

    [DataContract]
    public class Square : Shape { }
}
