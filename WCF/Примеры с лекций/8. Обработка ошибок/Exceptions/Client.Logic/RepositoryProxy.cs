using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.Logic.FaultServiceReference;

namespace Client.Logic
{
    public class RepositoryProxy
    {
        public async Task<string> GetDataAsync()
        {
            var proxy = new FaultServiceClient();

            try
            {
                return await proxy.GetDataAsync();
            }
            catch (FaultException<GetDataFault> ex)
            {
                //Известный сбой на сервере
                throw new Exception("Get data fault");
            }
            catch (FaultException ex)
            {
                //Неизвестный сбой на сервере
                throw new Exception("Some fault");
            }

            return null;
        }
    }
}
