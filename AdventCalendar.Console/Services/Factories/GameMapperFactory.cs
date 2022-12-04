using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;

namespace AdventCalendar.Console.Services.Factories
{
    public class GameMapperFactory : IGameMapperFactory
    {
        private readonly IEnumerable<IGameMapper> _gameMappers;

        public GameMapperFactory(IEnumerable<IGameMapper> gameMappers)
        {
            _gameMappers = gameMappers;
        }

        public IGameMapper Create(InputOrientation orientation)
        {
            return _gameMappers.First(f => f.Orientation == orientation);
        }
    }
}
