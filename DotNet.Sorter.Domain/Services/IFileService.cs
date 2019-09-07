using System.Collections.Generic;

namespace DotNet.Sorter.Domain.Services
{
    public interface IFileService<T>
    {
        IList<T> ReadFromFile(string path);
        bool WriteToFile(string path, IList<T> dataList);
    }
}
