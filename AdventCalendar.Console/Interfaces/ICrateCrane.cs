using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Interfaces
{
    public interface ICrateCrane
    {
        IEnumerable<CrateStack> MoveCrates(IEnumerable<CrateStack> crates, 
            IEnumerable<MoveCommand> commands);
    }
}
