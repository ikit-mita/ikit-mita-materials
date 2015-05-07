using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost.Model
{
    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public string StringValue { get; set; }

        // не является частью контракта данных
        public bool BoolValue { get; set; }
    }

}
