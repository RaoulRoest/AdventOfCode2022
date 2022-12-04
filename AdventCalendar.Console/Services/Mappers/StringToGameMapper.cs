using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToGameMapper : IGameMapper
    {
        private readonly string _sep = " ";

        public InputOrientation Orientation => InputOrientation.Hand;

        public RockPaperScissorGame Map(string handline)
        {
            var hands = handline.Split(_sep);
            return new RockPaperScissorGame(hands[0], hands[1]);
        }
    }
}
