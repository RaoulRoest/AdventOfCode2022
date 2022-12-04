using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToGameMapperStateBased : IGameMapper
    {
        private readonly string _sep = " ";

        private readonly Dictionary<string, GameStates> _stateMap =
            new Dictionary<string, GameStates>()
            {
                {"X", GameStates.Lose },
                {"Y", GameStates.Draw },
                {"Z", GameStates.Win },
            };

        public InputOrientation Orientation => InputOrientation.GameState;

        public RockPaperScissorGame Map(string handline)
        {
            var values = handline.Split(_sep);
            var state = _stateMap[values[1]];

            return new RockPaperScissorGame(values[0], state);
        }
    }
}
