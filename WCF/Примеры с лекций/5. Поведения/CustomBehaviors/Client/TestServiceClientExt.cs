using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.TestServiceReference;

namespace Client
{
    public  class TestServiceClientExt : TestServiceClient
    {
        public TestServiceClientExt()
        {
            Endpoint.Behaviors.Add(new SecurityTokenEndpointBehavior());
        }
    }
}
