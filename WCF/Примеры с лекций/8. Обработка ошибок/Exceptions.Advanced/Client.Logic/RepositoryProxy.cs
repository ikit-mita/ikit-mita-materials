using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.Logic.FaultServiceReference;
using Shared.Utils;

namespace Client.Logic
{
    public class RepositoryProxy
    {
        public async Task<string> GetDataAsync()
        {
            var proxy = new FaultServiceClientWrapper();

            try
            {
                return await proxy.GetDataAsync();
            }
            //catch (FaultException<GetDataFault> ex)
            catch (GetDataException ex)
            {
                //Известный сбой на сервере
                throw new Exception("Get data fault");
            }

            return null;
        }
    }
}
