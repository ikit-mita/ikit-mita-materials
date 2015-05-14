using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.Logic.FaultServiceReference;
using Shared.Utils;

namespace Client.Logic
{
public class FaultServiceClientWrapper : IFaultService
{
    private readonly FaultServiceClient _client = new FaultServiceClient();

    public async Task<string> GetDataAsync()
    {
        try
        {
            return await _client.GetDataAsync();
        }
        catch (FaultException<GetDataFault> ex)
        {
            throw new GetDataException();
        }
    }

    public string GetData()
    {
        throw new NotImplementedException();
    }
}

}
