using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DataContract;

namespace DataContractSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            XsdDataContractExporter xsdexp = new XsdDataContractExporter();
            xsdexp.Options = new ExportOptions();
            xsdexp.Export(typeof(Employee));

            // Write out exported schema to a file
            using (FileStream fs = new FileStream("sample.xsd", FileMode.Create))
                foreach (XmlSchema sch in xsdexp.Schemas.Schemas())
                    sch.Write(fs);
        }
    }
}
