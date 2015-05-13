using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost
{
    public class SecurityTokenMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var token = request.Headers.GetHeader<string>("SecurityToken", "");

            if (token != "KEY") throw new Exception("Invalid token");

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            
        }
    }
}
