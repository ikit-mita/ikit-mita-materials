using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StockService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StockService.svc or StockService.svc.cs at the Solution Explorer and start debugging.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)] 
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)] 
    public class StockService : IStockService
    {
        private static StringBuilder sb = new StringBuilder();

        public StockService()
        {
            sb.AppendFormat("{0}: Created new instance of StockService\n",
                DateTime.Now);
        }
        public double GetPrice(string ticker)
        {
            sb.AppendFormat("{0}: GetPrice called on thread {1}\n",
                DateTime.Now,
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return 94.85;
        }
    }
}
