namespace AdventCalendar.Console.Models
{
    public class ElfBackpackGroupModel
    {
        public IEnumerable<BackpackModel> Backpacks { get; protected set; }

        public ElfBackpackGroupModel(List<string> contents)
        {
            Backpacks = contents.Select(m => new BackpackModel(m));
        }

        public char FindBatch()
        {
            var foundCommon = Backpacks.First()
                .FindCommon(Backpacks.Skip(1).First().AllContents);

            for (int i = 2; i < Backpacks.Count(); i++)
            {
                var newCommonItems = Backpacks.Skip(i)
                    .First()
                    .FindCommon(foundCommon);
                foundCommon = foundCommon.Intersect(newCommonItems);
            }

            return foundCommon.First();
        }
    }
}
