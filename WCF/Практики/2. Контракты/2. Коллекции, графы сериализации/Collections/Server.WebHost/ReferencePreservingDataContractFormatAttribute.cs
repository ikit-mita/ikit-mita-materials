using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server.WebHost
{

    //http://www.codeproject.com/Articles/27308/WCF-A-few-tips
    /// <summary>
    /// Allows us to adorn the IService contract with this
    /// attribute to indicate that a specialized DataContractSerializer
    /// should be used that has preserveObjectReferences set true
    /// </summary>
    public class ReferencePreservingDataContractFormatAttribute
        : Attribute, IOperationBehavior
    {
        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description,
            BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description,
            System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyClientBehavior(description, proxy);
        }

        public void ApplyDispatchBehavior(OperationDescription description,
            System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyDispatchBehavior(description, dispatch);
        }

        public void Validate(OperationDescription description)
        {
        }

        #endregion
    }
}
