using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Console.Interfaces
{
    public interface IFileReaderFactory
    {
        IAsyncFileReader<List<string>> GetEmptyStringReader();
        IAsyncFileReader<List<string>> GetNCollectionFileReader(int n);
    }
}
