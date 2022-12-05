using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Logic
{
    public class CrateCraneLogic : ICrateCrane
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

            for (int i = 0; i < command.Amount; i++)
            {
                var crate = fromStack.GetTopCrate();
                toStack.AddCrate(crate);
            }
        }
    }
}
