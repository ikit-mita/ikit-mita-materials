using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace ReferencePreservation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>(6);
            Employee Employee1 = new Employee(1, "John");
            Employee Employee2 = new Employee(2, "Jane");

            list.Add(Employee1);
            list.Add(Employee2);
            list.Add(Employee1);
            

            FileStream writer = new FileStream("sample.xml", FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(
                type: typeof(List<Employee>),
                rootName: "root",
                rootNamespace: "rootns",
                knownTypes: null,
                maxItemsInObjectGraph: int.MaxValue,
                ignoreExtensionDataObject: false,
                preserveObjectReferences: true, // false is default value
                dataContractSurrogate: null);

            ser.WriteObject(writer, list);
            writer.Close();
        }
    }
}
