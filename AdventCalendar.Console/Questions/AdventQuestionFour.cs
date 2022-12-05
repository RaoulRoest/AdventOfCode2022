using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;
using AdventCalendar.Console.Questions.Base;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionFour : AdventQuestionBase
    {
        public override int Number => 4;

        private readonly IAsyncFileReader<string> _fileReader;
        private readonly IStringMapper<ElfCleaningDuoModel> _duoMapper;

        public AdventQuestionFour(
            IAsyncFileReader<string> fileReader,
            IStringMapper<ElfCleaningDuoModel> duoMapper)
        {
            _fileReader = fileReader;
            _duoMapper = duoMapper;
        }

        public override async Task<object> GetFirstAnswer()
        {
            var filePath = GetFilePath();
            return await _fileReader.ReadFileAsync(filePath)
                .Select(f => _duoMapper.Map(f))
                .Where(f => f.NeedsReconsideration())
                .CountAsync();
        }

        public override async Task<object> GetSecondAnswer()
        {
            var filePath = GetFilePath();
            return await _fileReader.ReadFileAsync(filePath)
                .Select(f => _duoMapper.Map(f))
                .Where(f => f.DoOverlap())
                .CountAsync();
        }
    }
}
