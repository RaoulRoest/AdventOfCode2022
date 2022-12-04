namespace AdventCalendar.Console.Models
{
    public class ElfCleaningDuoModel
    {
        public ElfCleaningDuoModel(ElfCleaningModel firstElf, ElfCleaningModel secondElf)
        {
            FirstElf = firstElf;
            SecondElf = secondElf;
        }

        public ElfCleaningModel FirstElf { get; set; }
        public ElfCleaningModel SecondElf { get; set; }

        public bool NeedsReconsideration()
        {
            return FirstElf.IsContainedIn(SecondElf) || SecondElf.IsContainedIn(FirstElf);
        }

        public bool DoOverlap()
        {
            return FirstElf.DoesOverlap(SecondElf) || SecondElf.DoesOverlap(FirstElf);
        }
    }
}
