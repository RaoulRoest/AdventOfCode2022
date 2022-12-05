using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Interfaces
{
    public interface IStringToCrateMapper
    {
        IDictionary<int, char> Map(string oneline);

        IEnumerable<CrateStack> Map(IEnumerable<string> multipleLines);
    }
}
