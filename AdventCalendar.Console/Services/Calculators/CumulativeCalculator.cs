using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.Calculators
{
    public class CumulativeCalculator : ICalculator<int>
    {
        public int Calculate(IEnumerable<int> input)
        {
            var sum = 0;
            foreach (var val in input)
            {
                sum += val;
            }

            return sum;
        }
    }
}
