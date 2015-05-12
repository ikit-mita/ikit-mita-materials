using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared.Model
{
    [DataContract]
    public class Order : DomainObject
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public List<OrderItem> OrderItems { get; set; }
    }
}
