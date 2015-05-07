using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.WebHost.Model;

namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShapeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShapeService.svc or ShapeService.svc.cs at the Solution Explorer and start debugging.
    public class ShapeService : IShapeService
    {
        public Shape CreateShape(int type)
        {
            if (type == 0) return new Circle();
            return new Square();

        }
    }
}
