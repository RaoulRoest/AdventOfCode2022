using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Logic
{
    public class CrateCrane9001Logic : ICrateCrane
    {
        public IEnumerable<CrateStack> MoveCrates(IEnumerable<CrateStack> crates,
            IEnumerable<MoveCommand> commands)
        {
            foreach (var command in commands)
            {
                ApplyCommand(crates, command);
            }

            return crates;
        }

        private void ApplyCommand(IEnumerable<CrateStack> crates, MoveCommand command)
        {
            var fromStack = crates.FirstOrDefault(f => f.Number == command.From);
            var toStack = crates.FirstOrDefault(f => f.Number == command.To);

            if (fromStack == null || toStack == null)
                throw new NullReferenceException();

            var cratesToMove = new char[command.Amount];
            for (int i = 0; i < command.Amount; i++)
            {
                var crate = fromStack.GetTopCrate();
                cratesToMove[i] = crate;
            }

            for (int i = command.Amount - 1; i >= 0; i--)
            {
                toStack.AddCrate(cratesToMove[i]);
            }
        }
    }
}
