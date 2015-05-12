using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    [DataContract]
    public class Customer : DomainObject
    {
        [DataMember]
        public string Name { get; set; }
    }
}
