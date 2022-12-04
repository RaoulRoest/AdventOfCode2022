namespace AdventCalendar.Console.Models
{
    public class BackpackModel
    {
        public BackpackModel(string contents)
        {
            FillBackpack(contents);
        }

        public void FillBackpack(string contents)
        {
            var length = contents.Length;
            AllContents = contents.ToCharArray();

            FirstCompartment = new char[length / 2];
            SecondCompartment = new char[length / 2];

            Array.Copy(AllContents, 0, FirstCompartment, 0, length / 2);
            Array.Copy(AllContents, length / 2, SecondCompartment, 0, length / 2);
        }

        public char FindDoublePacked()
        {
            return FirstCompartment.Intersect(SecondCompartment).First();
        }

        public IEnumerable<char> FindCommon(IEnumerable<char> other)
        {
            return AllContents.Intersect(other);
        }

        public char[] AllContents { get; protected set; }
        public char[] FirstCompartment { get; protected set; }
        public char[] SecondCompartment { get; protected set; }
    }
}
