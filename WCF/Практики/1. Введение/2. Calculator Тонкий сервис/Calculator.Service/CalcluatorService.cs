namespace Calculator.Service
{
    public class CalcluatorService : ICalculatorService
    {
        private readonly Logic.Calculator _calculator = new Logic.Calculator();

        public int Sum(int a, int b)
        {
            return _calculator.Sum(a, b);
        }
    }
}
