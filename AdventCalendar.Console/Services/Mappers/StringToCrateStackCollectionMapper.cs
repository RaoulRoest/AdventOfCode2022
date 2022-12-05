using AdventCalendar.Console.Interfaces;
using AdventCalendar.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Console.Services.Mappers
{
    public class StringToCrateStackCollectionMapper : IStringToCrateMapper
    {
        public IDictionary<int, char> Map(string value)
        {
            var charArray = value.ToCharArray();
            var index = 1;

            var crateCollection = new Dictionary<int, char>();
            for (int i = 1; i < charArray.Length; i += 4)
            {
                if (!(charArray[i] == ' '))
                    crateCollection[index] = charArray[i];

                index++;
            }

            return crateCollection;
        }

        public IEnumerable<CrateStack> Map(IEnumerable<string> multipleLines)
        {
            var collection = new Dictionary<int, List<char>>();
            foreach (var line in multipleLines)
            {
                var result = Map(line);

                foreach (var key in result.Keys)
                {
                    if (!collection.ContainsKey(key))
                        collection[key] = new List<char>();

                    collection[key].Add(result[key]);
                }
            }

            var crateStacks = new List<CrateStack>();
            foreach (var key in collection.Keys)
            {
                var stringValue = new string(collection[key].ToArray());
                var crate = new CrateStack(key, stringValue);
                crateStacks.Add(crate);
            }

            return crateStacks;
        }
    }
}
