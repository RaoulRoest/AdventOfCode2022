using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToBackpackMapper : IStringMultiMapper<BackpackModel>
    {
        public BackpackModel Map(string value)
        {
            return new BackpackModel(value);
        }

        public IEnumerable<BackpackModel> Map(IEnumerable<string> values)
        {
            foreach (var content in values)
            {
                yield return Map(content);
            }
        }
    }
}
