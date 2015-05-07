using System.ServiceModel;

namespace Calculator.Service
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Sum(int a, int b);
    }
}
