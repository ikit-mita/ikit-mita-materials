using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class TestService : ITestService
    {
        public string GetData()
        {
            return "Data";
        }
    }
}
