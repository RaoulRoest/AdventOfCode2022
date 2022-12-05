namespace AdventCalendar.Console.Models
{
    public class CrateStack
    {
        private readonly Stack<char> _crates;
        public int Number { get; }

        public CrateStack(int number)
        {
            Number = number;
            _crates = new Stack<char>();
        }

        public CrateStack(int number, string values)
            : this(number)
        {
            var charArray = values.ToCharArray();

            for(var i = charArray.Length - 1; i >= 0; i--)   
            {
                AddCrate(charArray[i]);
            }
        }

        public void AddCrate(char crate)
        {
            _crates.Push(crate);
        }

        public char GetTopCrate()
        {
            var letter = _crates.Pop();
            return letter;
        }
    }
}
