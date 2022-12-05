using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;
using AdventCalendar.Console.Questions.Base;

namespace AdventCalendar.Console.Questions
{
    public class AdventQuestionThree : AdventQuestionBase
    {
        public override int Number => 3;

        private readonly IAsyncFileReader<string> _reader;
        private readonly IStringMultiMapper<BackpackModel> _backpacker;
        private readonly ICharMapper<int> _charMapping;

        private readonly IFileReaderFactory _fileReaderFactory;

        public AdventQuestionThree(
            IAsyncFileReader<string> reader,
            IStringMultiMapper<BackpackModel> backpacker,
            ICharMapper<int> charMapping,
            IFileReaderFactory fileReaderFactory)
        {
            _reader = reader;
            _backpacker = backpacker;
            _charMapping = charMapping;
            _fileReaderFactory = fileReaderFactory;
        }

        public override async Task<object> GetFirstAnswer()
        {
            var filePath = GetFilePath();
            return await _reader.ReadFileAsync(filePath)
                .Select(contents => _backpacker.Map(contents).FindDoublePacked())
                .Select(doublePacked => _charMapping.Map(doublePacked))
                .SumAsync();
        }

        public override async Task<object> GetSecondAnswer()
        {
            var filePath = GetFilePath();
            var fileReader = _fileReaderFactory.GetNCollectionFileReader(3);
            return await fileReader.ReadFileAsync(filePath)
                .Select(l => new ElfBackpackGroupModel(l))
                .Select(g => g.FindBatch())
                .Select(b => _charMapping.Map(b))
                .SumAsync();
        }
    }
}
