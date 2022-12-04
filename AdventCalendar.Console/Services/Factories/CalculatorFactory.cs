using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Services.Calculators;

namespace AdventCalendar.Console.Services.Factories
{
    public class CalculatorFactory : ICalculatorFactory
    {
        public ICalculator<int> CreateCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.Maximum:
                    return new MaximumCalculator();
                case CalculatorType.CumulativeSum:
                    return new CumulativeCalculator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
