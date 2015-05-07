using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Calculator.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculatorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalculatorService.svc or CalculatorService.svc.cs at the Solution Explorer and start debugging.
    public class CalculatorService : ICalculatorService
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
