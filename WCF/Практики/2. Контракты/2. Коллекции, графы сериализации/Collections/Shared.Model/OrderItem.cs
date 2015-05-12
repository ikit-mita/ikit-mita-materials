using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    [DataContract]
    public class OrderItem : DomainObject
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public Order Order { get; set; }
        [DataMember]
        public Product Product { get; set; }
    }
}
