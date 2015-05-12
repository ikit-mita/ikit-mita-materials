using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    [DataContract]
    public class OrderRequest
    {
        [DataMember]
        public bool IncludeOrderItems { get; set; }

        [DataMember]
        public bool IncludeCustomer { get; set; } 
    }
}
