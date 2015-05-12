using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    [DataContract]
    public class Product : DomainObject
    {

        [DataMember]
        public string Name { get; set; }
    }
}
