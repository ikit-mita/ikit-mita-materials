using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server.WebHost
{
    //http://www.codeproject.com/Articles/27308/WCF-A-few-tips
    /// <summary>
    /// A specialized DataContractSerializer that has 
    /// preserveObjectReferences set true, which allows for
    /// circular references to be serialized
    /// </summary>
    public class ReferencePreservingDataContractSerializerOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        #region Ctor
        public ReferencePreservingDataContractSerializerOperationBehavior(
            OperationDescription operationDescription)
            : base(operationDescription) { }
        #endregion

        #region Public Methods

        public override XmlObjectSerializer CreateSerializer(Type type,
               XmlDictionaryString name, XmlDictionaryString ns,
               IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                2147483646 /*maxItemsInObjectGraph*/,
                false/*ignoreExtensionDataObject*/,
                true/*preserveObjectReferences*/,
                null/*dataContractSurrogate*/);
        }
        #endregion
    }
}
