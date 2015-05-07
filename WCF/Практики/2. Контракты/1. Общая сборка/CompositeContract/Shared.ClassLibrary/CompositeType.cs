using System.Runtime.Serialization;

namespace Shared.ClassLibrary
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
