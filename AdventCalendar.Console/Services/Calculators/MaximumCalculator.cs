using AdventCalendar.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Console.Services.Calculators
{
    public class MaximumCalculator : ICalculator<int>
    {
        public int Calculate(IEnumerable<int> input)
        {
            var max = 0;
            foreach (var val in input)
            {
                if (val > max)
                    max = val;
            }

            return max;
        }
    }
}
