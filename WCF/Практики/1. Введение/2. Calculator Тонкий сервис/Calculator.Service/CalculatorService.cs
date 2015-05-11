namespace Calculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        private readonly Logic.Calculator _calculator = new Logic.Calculator();

        public int Sum(int a, int b)
        {
            return _calculator.Sum(a, b);
        }
    }
}
