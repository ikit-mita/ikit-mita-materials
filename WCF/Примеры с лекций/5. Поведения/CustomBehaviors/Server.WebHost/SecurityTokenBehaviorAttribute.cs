using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost
{
    public class SecurityTokenBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                {
                    epDisp.DispatchRuntime.MessageInspectors.Add(new SecurityTokenMessageInspector());
                }
            }
        }
    }
}
