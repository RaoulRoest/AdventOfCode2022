using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToIntListMapper : IStringMultiMapper<int>
    {
        public IEnumerable<int> Map(IEnumerable<string> input)
        {
            foreach (var stringItem in input)
            {
                yield return Map(stringItem);
            }
        }

        public int Map(string input)
        {
            if (int.TryParse(input, out var result))
            {
                return result;
            }

            throw new ArgumentException("String is not parsable", nameof(input));
        }
    }
}
