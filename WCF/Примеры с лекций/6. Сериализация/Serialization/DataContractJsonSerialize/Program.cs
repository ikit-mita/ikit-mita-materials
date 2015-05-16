using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace DataContractJsonSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee(101, "John");
            FileStream writer = new FileStream("sample.json", FileMode.Create);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(writer, e);
            writer.Close();
        }
    }
}
