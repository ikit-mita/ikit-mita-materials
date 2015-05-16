using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace DataContractSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee(101, "John");
            FileStream writer = new FileStream("sample.xml", FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(Employee));
            ser.WriteObject(writer, e);
            writer.Close();
        }
    }
}
