using AdventCalendar.Console.Enums;
using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Questions.Base;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionTwo : AdventQuestionBase
    {
        public override int Number => 2;

        private readonly IAsyncFileReader<string> _reader;
        private readonly IGameMapperFactory _gameMapperFactory;

        public AdventQuestionTwo(
            IAsyncFileReader<string> reader,
            IGameMapperFactory gameMapperFactory)
        {
            _reader = reader;
            _gameMapperFactory = gameMapperFactory;
        }

        public override async Task<int> GetFirstAnswer()
        {
            var mapper = _gameMapperFactory.Create(InputOrientation.Hand);
            return await ComputeScore(mapper);
        }

        public override async Task<int> GetSecondAnswer()
        {
            var mapper = _gameMapperFactory.Create(InputOrientation.GameState);
            return await ComputeScore(mapper);
        }

        private async Task<int> ComputeScore(IGameMapper mapper)
        {
            var filePath = GetFilePath();
            return await _reader.ReadFileAsync(filePath)
                .Where(f => !string.IsNullOrEmpty(f))
                .Select(f => mapper.Map(f))
                .Select(g => g.CalculatePoints())
                .SumAsync();
        }
    }
}
