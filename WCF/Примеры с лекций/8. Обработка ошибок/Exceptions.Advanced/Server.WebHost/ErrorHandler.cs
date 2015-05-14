using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Shared.Utils;

namespace Server.WebHost
{
    public class ErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            FaultException faultException = null;
            if (error is GetDataException)
                faultException = new FaultException<GetDataFault>(new GetDataFault());

            if (faultException != null)
                fault = Message.CreateMessage(version, faultException.CreateMessageFault(), faultException.Action);
        }
        public bool HandleError(Exception error)
        {
            return true; //исключение было обработано
        }
    }

}
