using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Interfaces
{
    public interface IGameMapper
    {
        public InputOrientation Orientation { get; }
        RockPaperScissorGame Map(string handline);
    }
}
