using System.Collections.Generic;

namespace DotNet.Sorter.Domain.IRepositories
{
    public interface ILocalRepository<T>
    {
        IList<T> GetList(string path);
        bool Save(string path, IList<T> dataList);
    }
}
