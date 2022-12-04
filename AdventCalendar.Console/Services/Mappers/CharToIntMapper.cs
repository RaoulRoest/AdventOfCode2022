using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.Mappers
{
    public class CharToIntMapper : ICharMapper<int>
    {
        public int Map(char value)
        {
            // Is upper case
            if (value < 96)
            {
                return value - 64 + 26;
            }
            // Is lower case
            else
            {
                return value - 96;
            }
        }
    }
}
