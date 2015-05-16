using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(int employeeID, string firstName)
        {
            this.EmployeeId = employeeID;
            this.FirstName = firstName;
        }

        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

    }
}
