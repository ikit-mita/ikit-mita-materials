using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost
{
    [DataContract]
    public class GetDataFault
    {
        [DataMember]
        public string Data { get; set; }
    }

}
