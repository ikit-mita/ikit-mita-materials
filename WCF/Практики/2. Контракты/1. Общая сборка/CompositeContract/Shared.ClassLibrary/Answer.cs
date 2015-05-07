using System.Runtime.Serialization;

namespace Shared.ClassLibrary
{
    [DataContract]
    public enum Answer
    {
        [EnumMember]
        Yes,
        [EnumMember]
        No
    }

}
