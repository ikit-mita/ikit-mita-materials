using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SecurityTokenMessageInspector : IClientMessageInspector
    {
        private Message TraceMessage(MessageBuffer buffer)
        {
            Message msg = buffer.CreateMessage();
            System.Diagnostics.Trace.WriteLine(msg);
            return buffer.CreateMessage();
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(MessageHeader.CreateHeader("SecurityToken", "", "KEY"));
            request = TraceMessage(request.CreateBufferedCopy(int.MaxValue));
            return null;

        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
