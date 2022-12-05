using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToMoveCommandMapper : IStringMapper<MoveCommand>
    {
        public MoveCommand Map(string value)
        {
            var move = value.Split(" ");

            if (int.TryParse(move[1], out var amount)
                && int.TryParse(move[3], out var from)
                && int.TryParse(move[5], out var to))
            {
                return new MoveCommand()
                {
                    Amount = amount,
                    From = from,
                    To = to
                };
            }

            throw new ArgumentException("The given line was not formatted in the correct way");
        }
    }
}
