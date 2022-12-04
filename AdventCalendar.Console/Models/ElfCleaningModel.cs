namespace AdventCalendar.Console.Models
{
    public class ElfCleaningModel
    {
        private readonly string _sep = "-";
        public int StartSection { get; protected set; }
        public int EndSection { get; protected set; }

        public ElfCleaningModel(string sections)
        {
            var sectionSplit = sections.Split(_sep);

            if (int.TryParse(sectionSplit[0], out var startSection))
                StartSection = startSection;
            if (int.TryParse(sectionSplit[1], out var endSection))
                EndSection = endSection;
        }

        public bool IsContainedIn(ElfCleaningModel other)
        {
            return other.StartSection <= StartSection && other.EndSection >= EndSection;
        }

        public bool DoesOverlap(ElfCleaningModel other)
        {
            return !(EndSection < other.StartSection || other.EndSection < StartSection);
        }
    }
}
